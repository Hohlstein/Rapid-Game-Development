/*
Author: Klaus Wiegmann
*/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListItem_X : MonoBehaviour
{
    public Button x_button;
    public Button listitem_button;
    public HireList_ItemHandler itemHandler;
    public HiredEmployees HiredEmployees_object; 
    private EventSystem eventSystem;

    public float distanceThreshold;
    private bool clickable;
    private int ID;

    // Start is called before the first frame update
    void Start()
    {
        x_button = GetComponent<Button>();
        listitem_button = GetComponent<Button>();
        eventSystem = FindObjectOfType<EventSystem>();
        clickable = true;
        ID = itemHandler.GetID();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eventSystem != null && x_button != null && listitem_button != null)
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 buttonPosition = RectTransformUtility.WorldToScreenPoint(null, x_button.transform.position);

            float distance = Vector2.Distance(mousePosition, buttonPosition);
            HireList_ItemHandler[] instances = Object.FindObjectsOfType<HireList_ItemHandler>();
            if (distance <= distanceThreshold)
            {
                x_button.OnPointerEnter(new PointerEventData(eventSystem));
                foreach (HireList_ItemHandler instance in instances)
                {
                    Button instance_button = GetComponent<Button>();
                    instance_button.interactable = false;
                }
                if (Input.GetMouseButtonDown(0) && clickable){
                    clickable = false;
                    HiredEmployees_object.set(ID,false);
                }               
            }
            else
            {
                x_button.OnPointerExit(new PointerEventData(eventSystem));
                listitem_button.interactable = true;
                
            }
    }     
    }

    public void setHireListObject(HiredEmployees list){
        HiredEmployees_object = list;
    }
}
