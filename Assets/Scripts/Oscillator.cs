using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    float movementFactor;
    void Start()
    {
        startingPosition = transform.position;
    }
    void Update()
    {
        if (period <= Mathf.Epsilon) {return;}
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
   
        Vector3 offset = movementVector * rawSinWave ;
        transform.position = startingPosition + offset;

    }
}
