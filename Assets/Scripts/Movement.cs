using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]
    float mainUp = 1000;
     [SerializeField]
    float mainRoate = 100;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementUp();
        MovementRotate();
        
    }

    void MovementUp() {
        if (Input.GetKey(KeyCode.Space)) {
          rb.AddRelativeForce(Vector3.up * mainUp * Time.deltaTime);
        }

    }
    void MovementRotate() {
          if (Input.GetKey(KeyCode.A)) {
            ApplyRotation(1);
        } 
        else if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(-1);

        }
    }

    void ApplyRotation(float sign) {
        rb.freezeRotation = true;
        transform.Rotate(sign * Vector3.forward * mainRoate * Time.deltaTime); 
        rb.freezeRotation = false;
    }
}
