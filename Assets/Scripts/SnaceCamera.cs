using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float amount = 1;
    public float speed = 1;

    private Vector3 startPos;
    private float distation;
    private Vector3 rotation = Vector3.zero;

    private void Start()
    {
        startPos = transform.position;
    }
    
    private void Update()
    {
        distation += (transform.position - startPos).magnitude;
        startPos = transform.position;
        rotation.z = Mathf.Sin(distation * speed) * amount;
        transform.localEulerAngles = rotation;
    }

}
