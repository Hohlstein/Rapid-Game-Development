/*
Author: Fabian Wiehn
*/
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Select_DisplayEmployeeChat : MonoBehaviour{
    public EmployeeInfo employeeInfo;
    public HiredEmployees hireList;

    public Image selectedObject;
    public Sprite selectedSprite;
    public Sprite defaultSprite;
    public Sprite answeredSprite;
    public TextMeshProUGUI selectedEmployeeName;
    
    public GameObject sentText;
    public TextMeshProUGUI sentTextField;
    public GameObject recievedText;
    private bool answeredEmployee_1;
    private bool answeredEmployee_2;
    private bool answeredEmployee_3;
    private bool answeredEmployee_4;

    private List<PlayerAnswer> answerOptions;
    public List<DialogueTreeRoot> dialogues;
    public GameObject chooseOptionbarParent;
    public TextMeshProUGUI chooseOptionbar;
    private int dialogueIndex;
    private int answerIndex;

    void Start() {
        sentText.SetActive(false);
        recievedText.SetActive(false);
        chooseOptionbarParent.SetActive(false);
        answeredEmployee_1 = false;
        answeredEmployee_2 = false;
        answeredEmployee_3 = false;
        answeredEmployee_4 = false;

    }

    void Update() {
        
    }

    public void DisplaySelectedName(GameObject clickedObject) {
        string buttonText = clickedObject.GetComponentInChildren<TextMeshProUGUI>().text; 
        selectedEmployeeName.text = buttonText;
        recievedText.SetActive(true);
        chooseOptionbarParent.SetActive(true);
    }

    public void Selected(Image clickedObject) {
        if (selectedObject.name != clickedObject.name)
        {
            ResetButton();
            selectedObject = clickedObject;
        }
        clickedObject.sprite = selectedSprite;

        recieveMessage(); //here temporary until dialogue event triggering issue is solved
    }

    private void ResetButton()
    {
        selectedObject.sprite = defaultSprite;
    }

    private void recieveMessage() {
        dialogueIndex =0; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        recievedText.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex].getDialogueStart().getText();
        answerOptions = dialogues[dialogueIndex].getDialogueStart().getPlayerAnswer();
        chooseOptionbar.text = answerOptions[answerIndex].getText();
    }

    public void AnswerOptionsDown() {
        if(answerOptions != null) {
            answerIndex++;
            if(answerIndex < answerOptions.Count) {
                chooseOptionbar.text = answerOptions[answerIndex].getText();
            }else{
                answerIndex =0;
                chooseOptionbar.text = answerOptions[answerIndex].getText();
            }
        }
    }
        //First click up isnt working ... some index issue 
        public void AnswerOptionsUp() {
            if(answerOptions != null) {
                if(answerIndex == 0) {
                    answerIndex = answerOptions.Count-1;
                    chooseOptionbar.text = answerOptions[answerIndex].getText();
                }else {
                    answerIndex--;
                    chooseOptionbar.text = answerOptions[answerIndex].getText();
                }
            }
        }
        

        public void sendMessage() {
            if(selectedObject.name == "Employee_1") {
                if(answeredEmployee_1 != true) {
                    answerOptions = dialogues[dialogueIndex].getDialogueStart().getPlayerAnswer();
                    Debug.Log(answerOptions.Count);
                    sentText.SetActive(true);
                    Debug.Log(answerOptions.Count);
                    sentTextField.text = answerOptions[answerIndex].getText();
                }
            }
            if(selectedObject.name == "Employee_2") {
                if(answeredEmployee_2 != true) {
                    answerOptions = dialogues[dialogueIndex].getDialogueStart().getPlayerAnswer();
                    Debug.Log(answerOptions.Count);
                    sentText.SetActive(true);
                    Debug.Log(answerOptions.Count);
                    sentTextField.text = answerOptions[answerIndex].getText();
                }
            }
            if(selectedObject.name == "Employee_3") {
                if(answeredEmployee_3 != true) {
                    answerOptions = dialogues[dialogueIndex].getDialogueStart().getPlayerAnswer();
                    Debug.Log(answerOptions.Count);
                    sentText.SetActive(true);
                    Debug.Log(answerOptions.Count);
                    sentTextField.text = answerOptions[answerIndex].getText();
                }
            }
            if(selectedObject.name == "Employee_4") {
                if(answeredEmployee_4 != true) {
                    answerOptions = dialogues[dialogueIndex].getDialogueStart().getPlayerAnswer();
                    Debug.Log(answerOptions.Count);
                    sentText.SetActive(true);
                    Debug.Log(answerOptions.Count);
                    sentTextField.text = answerOptions[answerIndex].getText();
                }
            }

            if(selectedObject.name == "Employee_1") {
                answeredEmployee_1 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSprite;
            }
            if(selectedObject.name == "Employee_2") {
                answeredEmployee_2 = true;
                chooseOptionbar.text = "";
            }
            if(selectedObject.name == "Employee_3") {
                answeredEmployee_3 = true;
                chooseOptionbar.text = "";
            }
            if(selectedObject.name == "Employee_4") {
                answeredEmployee_4 = true;
                chooseOptionbar.text = "";
            }
        }

}