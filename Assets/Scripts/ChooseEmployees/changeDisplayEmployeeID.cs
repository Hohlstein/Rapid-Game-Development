using TMPro;
using UnityEngine;


public class changeDisplayEmployeeID : MonoBehaviour
{
    public TextMeshProUGUI IDText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI AgeText;
    public TextMeshProUGUI RelationshipstatusText;
    public TextMeshProUGUI BioText;
    public EmployeeInfo infosource;

    private int ID = 0;

    public void Start(){
        IDText.text = "0";
        NameText.text = "NAME HERE";
        AgeText.text = "AGE HERE";
        RelationshipstatusText.text = "RELATIONSHIP HERE";
        BioText.text = "BIO HERE";
        ID = 0;
        UpdateTexts();
    }

    public void ChangeNumber(int direction)
    {
        ID += direction;
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        IDText.text = ID.ToString();
        NameText.text = infosource.GetValue(ID,"First_Name") + " " + infosource.GetValue(ID,"Last_Name");
        AgeText.text = infosource.GetValue(ID,"Age");
        RelationshipstatusText.text = infosource.GetValue(ID,"Relation");
        BioText.text = infosource.GetValue(ID,"Bio");
    }
}