using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private Collider interactHitbox;
    [SerializeField] private Image UI;

    private void Start()
    {
        interactHitbox = GetComponent<Collider>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Interactable>() is Interactable interactable)
        {
            UI.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.InvokeInteract();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        UI.gameObject.SetActive(false);
    }
}
