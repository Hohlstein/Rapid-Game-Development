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
    private int numberOfPeople;

    private int ID = 0;

    public void Start(){
        IDText.text = "0";
        NameText.text = "NAME HERE";
        AgeText.text = "AGE HERE";
        RelationshipstatusText.text = "RELATIONSHIP HERE";
        BioText.text = "BIO HERE";
        ID = 0;
    }

    public void Update(){
        UpdateTexts();
    }

    public void ChangeNumber(int direction)
    {
        numberOfPeople = infosource.getNumberOfPeople();
        ID = (ID + direction) % numberOfPeople;
        
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        IDText.text = ID.ToString();
        NameText.text = infosource.getValueString(ID,"firstName") + " " + infosource.getValueString(ID,"lastName");
        AgeText.text = infosource.getValueString(ID,"Age") + " years old";
        RelationshipstatusText.text = infosource.getValueString(ID,"relationshipStatus");
        BioText.text = infosource.getValueString(ID,"Bio");
    }
}