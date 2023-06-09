using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{  
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float mainUp = 500;
    [SerializeField] float mainRoate = 100;
    [SerializeField] ParticleSystem mainFlyAnimation;
    [SerializeField] ParticleSystem leftFlyAnimation;
    [SerializeField] ParticleSystem rightFlyAnimation;

    Rigidbody rb;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    void Update()
    {
        MovementUp();
        MovementRotate();
        
    }

    void MovementUp() {

        if (Input.GetKey(KeyCode.Space))
        {
            StartMoving();
        }
        else
        {
            StopMoving();
        }

    }
    void StartMoving()
    {
        rb.AddRelativeForce(Vector3.up * mainUp * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainFlyAnimation.isPlaying)
        {
            mainFlyAnimation.Play();
        }
    }
    private void StopMoving()
    {
        audioSource.Stop();
        mainFlyAnimation.Stop();
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
