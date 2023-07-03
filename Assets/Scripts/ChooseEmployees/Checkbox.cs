using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkbox : MonoBehaviour
{
    public changeDisplayEmployeeID ID_info;
    public HiredEmployees HiredEmployees;
    public Image image;
    public Sprite onSprite;
    public Sprite offSprite;

    private int ID;
    private bool toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void press(){
        if (toggle){
            toggle = false;
        }
        else{
            toggle = true;
        }
        HiredEmployees.set(ID,toggle);
    }

    // Update is called once per frame
    public void UpdateSprite()
    {
        ID = ID_info.getCurrentID();
        toggle = HiredEmployees.isHired(ID);
        if (toggle){
            image.sprite = onSprite;
        }
        else{
            image.sprite = offSprite;
        }
        
    }

}
