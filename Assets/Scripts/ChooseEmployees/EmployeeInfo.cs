using UnityEngine;
using System.Collections.Generic;

public class EmployeeInfo : MonoBehaviour
{
    public List<Dictionary<string, string>> valueList = new List<Dictionary<string,string>>();

    public void Start(){
        SetValue(0,"First_Name","John");
        SetValue(0,"Last_Name","Doe");
        SetValue(0,"Age","21");
        SetValue(0,"Relation","Single");
        SetValue(0,"Bio","Nothing much yet, I'm just kind of a loser, man!");

        SetValue(1,"First_Name","Abraham");
        SetValue(1,"Last_Name","Lincoln");
        SetValue(1,"Age","200");
        SetValue(1,"Relation","Dead");
        SetValue(1,"Bio","Nothing much yet, I'm just kind of a president, man!");
    } 

    public string GetValue(int ID,string key)
    {
        if (ID >= 0 && ID < valueList.Count)
        {
            return valueList[ID][key];
        }
        else
        {
            Debug.LogError("Invalid index!");
            return null;
        }
    }

    public void SetValue(int ID, string key, string value)
    {
        if (ID >= 0)
        {
            if (ID >= valueList.Count){
                Dictionary<string,string> emptyDictionary = new Dictionary<string,string>();
                valueList.Add(emptyDictionary);
            }
            if (valueList[ID].ContainsKey(key))
            {
                valueList[ID][key] = value;
            }
            else
            {
                valueList[ID].Add(key, value);
                Debug.Log(valueList[ID].ToString());
            }
        }
        else
        {
            Debug.LogError("Invalid index: Below 0!");
        }
    }
}