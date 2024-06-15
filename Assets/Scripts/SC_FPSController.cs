using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    private const float _walkingSpeed = 7.5f;
    private const float _runningSpeed = 11.5f;
    private const float _jumpSpeed = 8.0f;
    private const float _gravity = 20.0f;
    private const float _lookSpeed = 2.0f;
    private const float _lookXLimit = 45.0f;
    private bool _canMove = true;
    private Vector3 _prevPos;

    private CharacterController _controller;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationH = 0;
    private float _rotationV = 0;
    private float _cameraShakeCycle = 0;
    private float _shakeStrength = 1f;
    private float _shakeSpeed = 1f;
    private float _distance = 0f;

    [SerializeField] private Camera _camera;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _prevPos = transform.position;

        // блок курсора
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // бег
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = _canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float curSpeedZ = _canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float movementDirectionY = _moveDirection.y;
        _moveDirection = (transform.forward * curSpeedZ) + (transform.right * curSpeedX);
        _moveDirection.y = (Input.GetButton("Jump") && _canMove && _controller.isGrounded) ? _jumpSpeed : movementDirectionY;

        if (!_controller.isGrounded)
        {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }

        // движение контроллера
        _controller.Move(_moveDirection * Time.deltaTime);

        // игрок и камера
        if (_canMove)
        {
            _rotationV += -Input.GetAxis("Mouse Y") * _lookSpeed;
            _rotationV = Mathf.Clamp(_rotationV, -_lookXLimit, _lookXLimit);
            _camera.transform.localRotation = Quaternion.Euler(_rotationV, 0, 0);
            _rotationH += Input.GetAxis("Mouse X") * _lookSpeed;
        }

        _distance += (transform.position - _prevPos).magnitude;
        _prevPos = transform.position;
        _cameraShakeCycle = Mathf.Sin(_distance * _shakeSpeed) * _shakeStrength;
        transform.rotation = Quaternion.Euler(0, _rotationH, _cameraShakeCycle);
    }
}