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
    public Sprite answeredSelectedSprite;
    public Sprite answeredSprite;
    public TextMeshProUGUI selectedEmployeeName;
    
    
    private bool answeredEmployee_1;
    public GameObject recievedText_1;
    public GameObject sentText_1;
    private int dialogueIndex_1;
    private int answerIndex_1;

    private bool answeredEmployee_2;
    public GameObject recievedText_2;
    public GameObject sentText_2;
    private int dialogueIndex_2;
    private int answerIndex_2;

    private bool answeredEmployee_3;
    public GameObject recievedText_3;
    public GameObject sentText_3;
    private int dialogueIndex_3;
    private int answerIndex_3;

    private bool answeredEmployee_4;
    public GameObject recievedText_4;
    public GameObject sentText_4;
    private int dialogueIndex_4;
    private int answerIndex_4;

    private List<PlayerAnswer> answerOptions;
    public List<DialogueTreeRoot> dialogues;
    public GameObject chooseOptionbarParent;
    public TextMeshProUGUI chooseOptionbar;

    void Start() {
        sentText_1.SetActive(false);
        recievedText_1.SetActive(false);

        sentText_2.SetActive(false);
        recievedText_2.SetActive(false);

        sentText_3.SetActive(false);
        recievedText_3.SetActive(false);

        sentText_4.SetActive(false);
        recievedText_4.SetActive(false);

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
        chooseOptionbarParent.SetActive(true);
    }

    public void Selected(Image clickedObject) {
        recievedText_1.SetActive(false);
        recievedText_2.SetActive(false);
        recievedText_3.SetActive(false);
        recievedText_4.SetActive(false);
        if (selectedObject.name != clickedObject.name)
        {
            ResetButton();
            selectedObject = clickedObject;
        }
        clickedObject.sprite = selectedSprite;

        if(clickedObject.name == "Employee_1") {
            recievedText_1.SetActive(true);
            recieveMessage_1();
        }
        if(clickedObject.name == "Employee_2") {
            recievedText_2.SetActive(true);
            recieveMessage_2();
        }
        if(clickedObject.name == "Employee_3") {
            recievedText_3.SetActive(true);
            recieveMessage_3();
        }
        if(clickedObject.name == "Employee_4") {
            recievedText_4.SetActive(true);
            recieveMessage_4();
        }
    }

    private void ResetButton()
    {
        selectedObject.sprite = defaultSprite;
        if(answeredEmployee_1 == true) {
            selectedObject.sprite = answeredSprite;
            sentText_1.SetActive(false);
        }
        if(answeredEmployee_2 == true) {
            selectedObject.sprite = answeredSprite;
            sentText_2.SetActive(false);
        }
        if(answeredEmployee_3 == true) {
            selectedObject.sprite = answeredSprite;
            sentText_3.SetActive(false);
        }
        if(answeredEmployee_4 == true) {
            selectedObject.sprite = answeredSprite;
            sentText_4.SetActive(false);
        }
    }

    private void recieveMessage_1() {
        dialogueIndex_1 = 0; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        recievedText_1.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_1].getDialogueStart()[0].getText();
        recievedText_1.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_1].getDialogueStart()[0].getText();
        recievedText_1.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_1].getDialogueStart()[0].getText();
        recievedText_1.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_1].getDialogueStart()[0].getText();
        answerOptions = dialogues[dialogueIndex_1].getDialogueStart()[0].getPlayerAnswer();
        chooseOptionbar.text = answerOptions[answerIndex_1].getText();
    }

    private void recieveMessage_2() {
        dialogueIndex_2 = 1; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        recievedText_2.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_2].getDialogueStart()[0].getText();
        recievedText_2.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_2].getDialogueStart()[0].getText();
        recievedText_2.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_2].getDialogueStart()[0].getText();
        recievedText_2.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_2].getDialogueStart()[0].getText();
        answerOptions = dialogues[dialogueIndex_2].getDialogueStart()[0].getPlayerAnswer();
        chooseOptionbar.text = answerOptions[answerIndex_2].getText();
    }

    private void recieveMessage_3() {
        dialogueIndex_3 = 2; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        recievedText_3.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_3].getDialogueStart()[0].getText();
        recievedText_3.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_3].getDialogueStart()[0].getText();
        recievedText_3.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_3].getDialogueStart()[0].getText();
        recievedText_3.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_3].getDialogueStart()[0].getText();
        answerOptions = dialogues[dialogueIndex_3].getDialogueStart()[0].getPlayerAnswer();
        chooseOptionbar.text = answerOptions[answerIndex_3].getText();
    }

    private void recieveMessage_4() {
        dialogueIndex_4 = 3; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        recievedText_4.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_4].getDialogueStart()[0].getText();
        recievedText_4.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_4].getDialogueStart()[0].getText();
        recievedText_4.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_4].getDialogueStart()[0].getText();
        recievedText_4.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_4].getDialogueStart()[0].getText();
        answerOptions = dialogues[dialogueIndex_4].getDialogueStart()[0].getPlayerAnswer();
        chooseOptionbar.text = answerOptions[answerIndex_4].getText();
    }

    public void AnswerOptionsDown() {
        if(selectedObject.name == "Employee_1") {
            if(answerOptions != null) {
                answerIndex_1++;
                if(answerIndex_1 < answerOptions.Count) {
                    chooseOptionbar.text = answerOptions[answerIndex_1].getText();
                }else{
                    answerIndex_1 =0;
                    chooseOptionbar.text = answerOptions[answerIndex_1].getText();
                }
            }
        }
        if(selectedObject.name == "Employee_2") {
            if(answerOptions != null) {
                answerIndex_2++;
                if(answerIndex_2 < answerOptions.Count) {
                    chooseOptionbar.text = answerOptions[answerIndex_2].getText();
                }else{
                    answerIndex_2 =0;
                    chooseOptionbar.text = answerOptions[answerIndex_2].getText();
                }
            }
        }
        if(selectedObject.name == "Employee_3") {
            if(answerOptions != null) {
                answerIndex_3++;
                if(answerIndex_3 < answerOptions.Count) {
                    chooseOptionbar.text = answerOptions[answerIndex_3].getText();
                }else{
                    answerIndex_3 =0;
                    chooseOptionbar.text = answerOptions[answerIndex_3].getText();
                }
            }
        }
        if(selectedObject.name == "Employee_4") {
            if(answerOptions != null) {
                answerIndex_4++;
                if(answerIndex_4 < answerOptions.Count) {
                    chooseOptionbar.text = answerOptions[answerIndex_4].getText();
                }else{
                    answerIndex_4 =0;
                    chooseOptionbar.text = answerOptions[answerIndex_4].getText();
                }
            }
        }
        
    }
 
    public void AnswerOptionsUp() {
        if(selectedObject.name == "Employee_1") {
            if(answerOptions != null) {
                if(answerIndex_1 == 0) {
                    answerIndex_1 = answerOptions.Count-1;
                    chooseOptionbar.text = answerOptions[answerIndex_1].getText();
                }else {
                    answerIndex_1--;
                    chooseOptionbar.text = answerOptions[answerIndex_1].getText();
                }
            }
        }
        if(selectedObject.name == "Employee_2") {
            if(answerOptions != null) {
                if(answerIndex_2 == 0) {
                    answerIndex_2 = answerOptions.Count-1;
                    chooseOptionbar.text = answerOptions[answerIndex_2].getText();
                }else {
                    answerIndex_2--;
                    chooseOptionbar.text = answerOptions[answerIndex_2].getText();
                }
            }
        }
        if(selectedObject.name == "Employee_3") {
            if(answerOptions != null) {
                if(answerIndex_3 == 0) {
                    answerIndex_3 = answerOptions.Count-1;
                    chooseOptionbar.text = answerOptions[answerIndex_3].getText();
                }else {
                    answerIndex_3--;
                    chooseOptionbar.text = answerOptions[answerIndex_3].getText();
                }
            }
        }
        if(selectedObject.name == "Employee_4") {
            if(answerOptions != null) {
                if(answerIndex_4 == 0) {
                    answerIndex_4 = answerOptions.Count-1;
                    chooseOptionbar.text = answerOptions[answerIndex_4].getText();
                }else {
                    answerIndex_4--;
                    chooseOptionbar.text = answerOptions[answerIndex_4].getText();
                }
            }
        }   
    }  

        public void sendMessage() {
            if(selectedObject.name == "Employee_1") {
                if(answeredEmployee_1 != true) {
                    answerOptions = dialogues[dialogueIndex_1].getDialogueStart()[0].getPlayerAnswer();
                    sentText_1.SetActive(true);
                    Debug.Log("Text sollte da stehen: "+answerOptions[answerIndex_1].getText());
                    sentText_1.GetComponentInChildren<TextMeshProUGUI>().text = answerOptions[answerIndex_1].getText();
                }
            }
            if(selectedObject.name == "Employee_2") {
                if(answeredEmployee_2 != true) {
                    answerOptions = dialogues[dialogueIndex_2].getDialogueStart()[0].getPlayerAnswer();
                    sentText_2.SetActive(true);
                    sentText_2.GetComponentInChildren<TextMeshProUGUI>().text = answerOptions[answerIndex_2].getText();
                }
            }
            if(selectedObject.name == "Employee_3") {
                if(answeredEmployee_3 != true) {
                    answerOptions = dialogues[dialogueIndex_3].getDialogueStart()[0].getPlayerAnswer();
                    sentText_3.SetActive(true);
                    sentText_3.GetComponentInChildren<TextMeshProUGUI>().text = answerOptions[answerIndex_3].getText();
                }
            }
            if(selectedObject.name == "Employee_4") {
                if(answeredEmployee_4 != true) {
                    answerOptions = dialogues[dialogueIndex_4].getDialogueStart()[0].getPlayerAnswer();
                    sentText_4.SetActive(true);
                    sentText_4.GetComponentInChildren<TextMeshProUGUI>().text = answerOptions[answerIndex_4].getText();
                }
            }

            if(selectedObject.name == "Employee_1") {
                answeredEmployee_1 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSelectedSprite;
            }
            
            if(selectedObject.name == "Employee_2") {
                answeredEmployee_2 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSelectedSprite;
            }
            if(selectedObject.name == "Employee_3") {
                answeredEmployee_3 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSelectedSprite;
            }
            if(selectedObject.name == "Employee_4") {
                answeredEmployee_4 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSelectedSprite;
            }
        }

}