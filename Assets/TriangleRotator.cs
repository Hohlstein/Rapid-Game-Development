using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleRotator : MonoBehaviour
{
    public float flipAmount = 10f;
    public float returnAmout = 0.9f;

    public void flip(float speed){
        Quaternion currentRotation = transform.rotation;
        float newZ = flipAmount + Mathf.Min(speed,15f);
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, newZ);
        transform.rotation = newRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = transform.rotation;
        float newZ = currentRotation.eulerAngles.z * returnAmout;
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, newZ);
        transform.rotation = newRotation;
    }
}
