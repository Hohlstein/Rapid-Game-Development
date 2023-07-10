/*
Author: Klaus Wiegmann
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    /*
    Diese allgemein verwendbare Skript erlaubt es Objekten, "smooth" von A nach B zu gleiten.
    Target_x, target_y sind immer die Zielorte, current_x, current_y die aktuelle Position.

    Friction gibt an, wie sehr das Gleiten verlangsamt wird.
      1 -> Teleportieren zum Zielort
      Höhere Werte -> Immer langsameres Gleiten

    */
    float target_x;
    float target_y;
    float current_x;
    float current_y;
    public float friction;
    public bool freeze;

    void Start()
    {
        /*
        Zu Beginn werden sowohl die aktuelle Position als auch die Zielposition auf die im Editor eingestellte Position des Objekts gestellt.
        */
        if (freeze == false){
            current_x = transform.position.x;
            current_y = transform.position.y;
            target_x = current_x;
            target_y = current_y;
        }

    }

    void Update()
    {
        if (freeze == false){
            /*
            Es wird in jedem Schritt die aktuelle Position berechet und damit die Differenz zur Zielposition berechnet.
            Da die Differenz immer durch Friction geteilt wird, kommt man nie in einem Schritt ganz ans Ziel, sondern bewegt sich immer nur einen Bruchteil der benötigten Strecke weiter.
            Dadurch entsteht eine "smoothe" Bewegung.
            */
            getPos();
            float x_change = (target_x-current_x)/friction;
            float y_change = (target_y-current_y)/friction;
            step(x_change,y_change);
        }
    }

    public void setTargetX(float x){
        target_x = x;
    }
    public void setTargetY(float y){
        target_y = y;
    }

    public void setCurrentX(float x){
        Vector3 newPosition = new Vector3(x, current_y);
        transform.position = newPosition;
        getPos();
    }
    public void setCurrentY(float y){
        Vector3 newPosition = new Vector3(current_x, y);
        transform.position = newPosition;
        getPos();
    }

    public void setFriction(float val){
        friction = val;
    }

    private void step(float x, float y){
        Vector3 newPosition = new Vector3(current_x + x, current_y + y);
        transform.position = newPosition;
    }

    private void getPos(){
        current_x = transform.position.x;
        current_y = transform.position.y;
    }
}
