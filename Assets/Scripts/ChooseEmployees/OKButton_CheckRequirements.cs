/*
Author: Klaus Wiegmann
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OKButton_CheckRequirements : MonoBehaviour
{
    public Button button;
    public HiredEmployees HiredEmployees;
    public GameObject ArbeitsTeilung;
    public GameObject HireList;


    void Start()
    {
        HireList.SetActive(true);
        ArbeitsTeilung.SetActive(false);

        button.onClick.AddListener(() => OnOkClick());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Im Men체 m체ssen genau 4 Angestellte ausgew채hlt werden. Daher ist der Button nur aktiviert, wenn genau 4 ausgew채hlt sind.
        */
        if (HiredEmployees.getNumberOfSelectedEmployees() == 4)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }


    public void OnOkClick()
    {
        HireList.SetActive(false);
        ArbeitsTeilung.SetActive(true);
    }
}