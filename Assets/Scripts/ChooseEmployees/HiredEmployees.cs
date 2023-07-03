using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiredEmployees : MonoBehaviour
{
    private Dictionary<int,bool> hired;
    private int n;

    // Start is called before the first frame update
    public void resetList(int n)
    {
        hired = new Dictionary<int,bool>();
        for (int i = 0; i < n; i++)
        {
            hired[i] = false;
        }
    }

    public Dictionary<int,bool> getHireList(){
        return hired;
    }

    public bool isHired(int ID){
        return hired[ID];
    }

    public void set(int ID, bool val){
        hired[ID] = val;
    }

}
