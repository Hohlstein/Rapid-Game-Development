//Autor: Klaus Wiegmann
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleRotator : MonoBehaviour
{
    //Dieses Skript kümmert sich um die Animation des kleinen Dreiecks am oberen Rand des Glücksrads.
    public float flipAmount = 10f;
    public float returnAmount = 0.9f;

    public void flip(float speed){
        //Je nach aktueller Drehgeschwindigkeit wird das Dreieck sofort gekippt.
        Quaternion currentRotation = transform.rotation;
        float newZ = flipAmount + Mathf.Min(speed,15f);
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, newZ);
        transform.rotation = newRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = transform.rotation;
        float z_rotation = currentRotation.eulerAngles.z;
        if (Mathf.Abs(z_rotation) > 60){
            //Damit das Dreieck nicht zu stark ausschlägt, wird der maximale Drehwinkel von 60° rechts oder links erzwungen.
            if (z_rotation > 0){
                setZ(60f);
            }
            else{
                setZ(-60f);
            }
            
        }
        //Durch Multiplizieren der aktuellen Rotation mit dem returnAmount wird das Dreieck langsam in seine Ausgangsposition zurückversetzt.
        float newZ = z_rotation * returnAmount;
        setZ(newZ);
        
    }

    private void setZ(float newZ){
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, newZ);
        transform.rotation = newRotation;
    }
}
