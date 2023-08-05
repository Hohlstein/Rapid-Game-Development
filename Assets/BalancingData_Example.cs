//Dieses Beispiel zeigt, wie man auf Werte in BalancingData zugreifen kann.
//Autor: Klaus Wiegmann


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancingData_Example : MonoBehaviour
{
    public BalancingData balancingData;
    void Start()
    {
        Debug.Log(balancingData.exampleVal1);
    }

}
