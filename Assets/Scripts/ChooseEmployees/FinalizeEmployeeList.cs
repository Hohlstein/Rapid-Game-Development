using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalizeEmployeeList : MonoBehaviour
{
    private HiredEmployees HireInfo;
    private List<Mitarbeiter> Hired_Employee_Objects;
    // Start is called before the first frame update

    public void FinalizeEmployees(){
        DontDestroyOnLoad(gameObject);
        HireInfo = GameObject.FindObjectOfType<HiredEmployees>();
        Dictionary<int,bool> BoolList = HireInfo.getHireList();
        GameObject[] employeeGameObjects = GameObject.FindGameObjectsWithTag("mitarbeiter"); 
        Hired_Employee_Objects = new List<Mitarbeiter>();
        for (int i = 0; i < employeeGameObjects.Length; i++)
        {
            Mitarbeiter current_employee = employeeGameObjects[i].GetComponent<Mitarbeiter>();
            if (BoolList[current_employee.getID()] == false){
                Destroy(employeeGameObjects[i]);
            }
            else{
                Hired_Employee_Objects.Add(current_employee);
            }
        }
    }

    public Mitarbeiter GetEmployee(int ID){
        for (int i = 0; i < Hired_Employee_Objects.Count; i++)
        {
            if (Hired_Employee_Objects[i].getID() == ID){
                return Hired_Employee_Objects[i];
            }
        }

        Debug.LogError("Tried to get Employee with ID "+ID.ToString()+", but no employee with that ID is in the finalized hire list.");
        return null;
    }

    public List<Mitarbeiter> GetEmployeeList(){
        return Hired_Employee_Objects;
    }


}
