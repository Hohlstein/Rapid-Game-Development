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
    
    public GameObject recievedPrefab;
    public GameObject sentPrefab;
    
    private bool answeredEmployee_1;
    public GameObject chatHolder_1;
    public GameObject chatScrollRect_1;
    private int dialogueIndex_1; 
    private int answerIndex_1;
    private int dialoguePositionIndex_1;
    private int answeredAmount_1;

    public GameObject chatScrollRect_2;
    public GameObject chatHolder_2;
    private bool answeredEmployee_2;
    private int dialogueIndex_2;
    private int answerIndex_2;
    private int answeredAmount_2;


    public GameObject chatScrollRect_3;
    public GameObject chatHolder_3;
    private bool answeredEmployee_3;
    private int dialogueIndex_3;
    private int answerIndex_3;
    private int answeredAmount_3;

    public GameObject chatScrollRect_4;
    public GameObject chatHolder_4;
    private bool answeredEmployee_4;
    private int dialogueIndex_4;
    private int answerIndex_4;
    private int answeredAmount_4;

    private List<PlayerAnswer> answerOptions;
    public List<DialogueTreeRoot> dialogues;
    public GameObject chooseOptionbarParent;
    public TextMeshProUGUI chooseOptionbar;

    void Start() {
        chatScrollRect_1.SetActive(false);
        chatScrollRect_2.SetActive(false);
        chatScrollRect_3.SetActive(false);
        chatScrollRect_4.SetActive(false);

        chooseOptionbarParent.SetActive(false);
        answeredEmployee_1 = false;
        answeredEmployee_2 = false;
        answeredEmployee_3 = false;
        answeredEmployee_4 = false;

    }

    void Update() {
        
    }

    public void DisplaySelectedName(GameObject clickedObject) {
        Transform findName;
        if(clickedObject.name == "Employee_1") {
            findName = clickedObject.transform.Find("employee_1_name");
            string buttonText = findName.GetComponent<TextMeshProUGUI>().text; 
            selectedEmployeeName.text = buttonText;
            chooseOptionbarParent.SetActive(true);
        }
        if(clickedObject.name == "Employee_2") {
            findName = clickedObject.transform.Find("employee_2_name");
            string buttonText = findName.GetComponent<TextMeshProUGUI>().text; 
            selectedEmployeeName.text = buttonText;
            chooseOptionbarParent.SetActive(true);
        }
        if(clickedObject.name == "Employee_3") {
            findName = clickedObject.transform.Find("employee_3_name");
            string buttonText = findName.GetComponent<TextMeshProUGUI>().text; 
            selectedEmployeeName.text = buttonText;
            chooseOptionbarParent.SetActive(true);
        }
        if(clickedObject.name == "Employee_4") {
            findName = clickedObject.transform.Find("employee_4_name");
            string buttonText = findName.GetComponent<TextMeshProUGUI>().text; 
            selectedEmployeeName.text = buttonText;
            chooseOptionbarParent.SetActive(true);
        }
        
    }
    //Bug: If answered then deselected and reselected answeredSprite isnt showing normal one is showing instead
    public void Selected(Image clickedObject) {
        chatScrollRect_1.SetActive(false);
        chatScrollRect_2.SetActive(false);
        chatScrollRect_3.SetActive(false);
        chatScrollRect_4.SetActive(false);

        if (selectedObject.name != clickedObject.name)
        {
            ResetButton();
            selectedObject = clickedObject;
        }
        clickedObject.sprite = selectedSprite;

        if(clickedObject.name == "Employee_1") {
            chatScrollRect_1.SetActive(true);
            recieveMessage_1();
        }
        if(clickedObject.name == "Employee_2") {
            chatScrollRect_2.SetActive(true);
            recieveMessage_2();
        }
        if(clickedObject.name == "Employee_3") {
            chatScrollRect_3.SetActive(true);
            recieveMessage_3();
        }
        if(clickedObject.name == "Employee_4") {
            chatScrollRect_4.SetActive(true);
            recieveMessage_4();
        }
    }
    //Bug: As soon as 1 is answered all get Answered Sprite once deselected
    private void ResetButton()
    {
        selectedObject.sprite = defaultSprite;
        if(answeredEmployee_1 == true) {
            selectedObject.sprite = answeredSprite;
            chatScrollRect_1.SetActive(false);
        }
        if(answeredEmployee_2 == true) {
            selectedObject.sprite = answeredSprite;
            chatScrollRect_2.SetActive(false);
        }
        if(answeredEmployee_3 == true) {
            selectedObject.sprite = answeredSprite;
            chatScrollRect_3.SetActive(false);
        }
        if(answeredEmployee_4 == true) {
            selectedObject.sprite = answeredSprite;
            chatScrollRect_4.SetActive(false);
        }
    }

    private void recieveMessage_1() {
        answeredAmount_1=0;
        dialogueIndex_1 = 3; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        GameObject recievedText_1 = Instantiate(recievedPrefab, chatHolder_1.transform);

        recievedText_1.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_1].getDialogueStart()[0].getText();
        answerOptions = dialogues[dialogueIndex_1].getDialogueStart()[0].getPlayerAnswer();
        chooseOptionbar.text = answerOptions[answerIndex_1].getText();
    }

    private void recieveMessage_2() {
        answeredAmount_2=0;
        dialogueIndex_2 = 3; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        GameObject recievedText_2 = Instantiate(recievedPrefab, chatHolder_2.transform);
        recievedText_2.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_2].getDialogueStart()[0].getText();
        answerOptions = dialogues[dialogueIndex_2].getDialogueStart()[0].getPlayerAnswer();
        chooseOptionbar.text = answerOptions[answerIndex_2].getText();
    }

    private void recieveMessage_3() {
        answeredAmount_3=0;
        dialogueIndex_3 = 3; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        GameObject recievedText_3 = Instantiate(recievedPrefab, chatHolder_3.transform);
        recievedText_3.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[dialogueIndex_3].getDialogueStart()[0].getText();
        answerOptions = dialogues[dialogueIndex_3].getDialogueStart()[0].getPlayerAnswer();
        chooseOptionbar.text = answerOptions[answerIndex_3].getText();
    }

    private void recieveMessage_4() {
        answeredAmount_4=0;
        dialogueIndex_4= 3; //param hardcoded for dev purposes will be changed once i got a way to trigger the right dialogues
        GameObject recievedText_4 = Instantiate(recievedPrefab, chatHolder_4.transform);
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

        public void sendAnswer() {
            if(selectedObject.name == "Employee_1") {
                if(answeredEmployee_1 != true) {
                    if(answeredAmount_1 == 0) {
                        answerOptions = dialogues[dialogueIndex_1].getDialogueStart()[0].getPlayerAnswer();
                        GameObject sentText_1 = Instantiate(sentPrefab,chatHolder_1.transform);
                        sentText_1.GetComponentInChildren<TextMeshProUGUI>().text = answerOptions[answerIndex_1].getText();
                        answeredAmount_1++;
                        if(answerOptions[answerIndex_1].getFinalNode() == false) {
                            int saveAnswerIndex = answerIndex_1;
                            answerIndex_1 = 0;
                            sendEmployeeAnswer(answerOptions[saveAnswerIndex].getNextNode());
                        }else{
                            answeredEmployee_1 = true;
                            chooseOptionbar.text = "";
                            selectedObject.sprite = answeredSelectedSprite;
                        }
                    }else{
                        Debug.Log("Text der gesendet wird: "+ chooseOptionbar.text);
                        GameObject sentText_1 = Instantiate(sentPrefab, chatHolder_1.transform);
                        for (int i = 0; i < answeredAmount_1; i++){
                            sentText_1.transform.position = sentText_1.transform.position- new Vector3(0f,450f);
                        }
                        sentText_1.GetComponentInChildren<TextMeshProUGUI>().text = chooseOptionbar.text;
                        answeredAmount_1++;
                        if(answerOptions[answerIndex_1].getFinalNode() == false) {
                            sendEmployeeAnswer(answerOptions[answerIndex_1].getNextNode());
                        }
                    }  
                }
            }

            if(selectedObject.name == "Employee_2") {
                if(answeredEmployee_2 != true) {
                    if(answeredAmount_2 == 0) {
                        answerOptions = dialogues[dialogueIndex_2].getDialogueStart()[0].getPlayerAnswer();
                        GameObject sentText_2 = Instantiate(sentPrefab,chatHolder_2.transform);
                        sentText_2.GetComponentInChildren<TextMeshProUGUI>().text = answerOptions[answerIndex_2].getText();
                        answeredAmount_2++;
                        if(answerOptions[answerIndex_2].getFinalNode() == false) {
                            int saveAnswerIndex = answerIndex_2;
                            answerIndex_2 = 0;
                            sendEmployeeAnswer(answerOptions[saveAnswerIndex].getNextNode());
                        }else{
                            answeredEmployee_2 = true;
                            chooseOptionbar.text = "";
                            selectedObject.sprite = answeredSelectedSprite;
                        }
                    }else{
                        Debug.Log("Text der gesendet wird: "+ chooseOptionbar.text);
                        GameObject sentText_2 = Instantiate(sentPrefab, chatHolder_2.transform);
                        for (int i = 0; i < answeredAmount_2; i++){
                            sentText_2.transform.position = sentText_2.transform.position- new Vector3(0f,450f);
                        }
                        sentText_2.GetComponentInChildren<TextMeshProUGUI>().text = chooseOptionbar.text;
                        answeredAmount_2++;
                        if(answerOptions[answerIndex_2].getFinalNode() == false) {
                            sendEmployeeAnswer(answerOptions[answerIndex_2].getNextNode());
                        }
                    }  
                }
            }
            if(selectedObject.name == "Employee_3") {
                if(answeredEmployee_3 != true) {
                    if(answeredAmount_3 == 0) {
                        answerOptions = dialogues[dialogueIndex_3].getDialogueStart()[0].getPlayerAnswer();
                        GameObject sentText_3 = Instantiate(sentPrefab,chatHolder_3.transform);
                        sentText_3.GetComponentInChildren<TextMeshProUGUI>().text = answerOptions[answerIndex_3].getText();
                        answeredAmount_3++;
                        if(answerOptions[answerIndex_3].getFinalNode() == false) {
                            int saveAnswerIndex = answerIndex_3;
                            answerIndex_3 = 0;
                            sendEmployeeAnswer(answerOptions[saveAnswerIndex].getNextNode());
                        }else{
                            answeredEmployee_3 = true;
                            chooseOptionbar.text = "";
                            selectedObject.sprite = answeredSelectedSprite;
                        }
                    }else{
                        Debug.Log("Text der gesendet wird: "+ chooseOptionbar.text);
                        GameObject sentText_3 = Instantiate(sentPrefab, chatHolder_3.transform);
                        for (int i = 0; i < answeredAmount_3; i++){
                            sentText_3.transform.position = sentText_3.transform.position- new Vector3(0f,450f);
                        }
                        sentText_3.GetComponentInChildren<TextMeshProUGUI>().text = chooseOptionbar.text;
                        answeredAmount_3++;
                        if(answerOptions[answerIndex_3].getFinalNode() == false) {
                            sendEmployeeAnswer(answerOptions[answerIndex_3].getNextNode());
                        }
                    }  
                }
            }
            if(selectedObject.name == "Employee_4") {
                if(answeredEmployee_4 != true) {
                    if(answeredAmount_4 == 0) {
                        answerOptions = dialogues[dialogueIndex_4].getDialogueStart()[0].getPlayerAnswer();
                        GameObject sentText_4 = Instantiate(sentPrefab,chatHolder_4.transform);
                        sentText_4.GetComponentInChildren<TextMeshProUGUI>().text = answerOptions[answerIndex_4].getText();
                        answeredAmount_4++;
                        if(answerOptions[answerIndex_4].getFinalNode() == false) {
                            int saveAnswerIndex = answerIndex_4;
                            answerIndex_4 = 0;
                            sendEmployeeAnswer(answerOptions[saveAnswerIndex].getNextNode());
                        }else{
                            answeredEmployee_4 = true;
                            chooseOptionbar.text = "";
                            selectedObject.sprite = answeredSelectedSprite;
                        }
                    }else{
                        Debug.Log("Text der gesendet wird: "+ chooseOptionbar.text);
                        GameObject sentText_4 = Instantiate(sentPrefab, chatHolder_4.transform);
                        for (int i = 0; i < answeredAmount_4; i++){
                            sentText_4.transform.position = sentText_4.transform.position- new Vector3(0f,450f);
                        }
                        sentText_4.GetComponentInChildren<TextMeshProUGUI>().text = chooseOptionbar.text;
                        answeredAmount_4++;
                        if(answerOptions[answerIndex_4].getFinalNode() == false) {
                            sendEmployeeAnswer(answerOptions[answerIndex_4].getNextNode());
                        }
                    }  
                }
            }
        }

    public void sendEmployeeAnswer(DialogueNode answer) {
        if(selectedObject.name == "Employee_1") {
            GameObject employeeAnswer = Instantiate(recievedPrefab,chatHolder_1.transform);
            employeeAnswer.GetComponentInChildren<TextMeshProUGUI>().text = answer.getText();
            for (int i = 0; i < answeredAmount_1; i++)
            {
                employeeAnswer.transform.position = employeeAnswer.transform.position - new Vector3(0f, 450f);
            }
            if(answer.getFinalNode() == false) {
                displayResponseToEmployeeAnswer(answer.getPlayerAnswer());
            }else{
                answeredEmployee_1 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSelectedSprite;
            } 
        }

        if(selectedObject.name == "Employee_2") {
            GameObject employeeAnswer = Instantiate(recievedPrefab,chatHolder_2.transform);
            employeeAnswer.GetComponentInChildren<TextMeshProUGUI>().text = answer.getText();
            for (int i = 0; i < answeredAmount_2; i++)
            {
                employeeAnswer.transform.position = employeeAnswer.transform.position - new Vector3(0f, 450f);
            }
            if(answer.getFinalNode() == false) {
                displayResponseToEmployeeAnswer(answer.getPlayerAnswer());
            }else{
                answeredEmployee_2 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSelectedSprite;
            }
        }
        if(selectedObject.name == "Employee_3") {
            GameObject employeeAnswer = Instantiate(recievedPrefab,chatHolder_3.transform);
            employeeAnswer.GetComponentInChildren<TextMeshProUGUI>().text = answer.getText();
            for (int i = 0; i < answeredAmount_3; i++)
            {
                employeeAnswer.transform.position = employeeAnswer.transform.position - new Vector3(0f, 450f);
            }
            if(answer.getFinalNode() == false) {
                displayResponseToEmployeeAnswer(answer.getPlayerAnswer());
            }else{
                answeredEmployee_3 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSelectedSprite;
            }
        }
        if(selectedObject.name == "Employee_4") {
            GameObject employeeAnswer = Instantiate(recievedPrefab,chatHolder_4.transform);
            employeeAnswer.GetComponentInChildren<TextMeshProUGUI>().text = answer.getText();
            for (int i = 0; i < answeredAmount_4; i++)
            {
                employeeAnswer.transform.position = employeeAnswer.transform.position - new Vector3(0f, 450f);
            }
            if(answer.getFinalNode() == false) {
                displayResponseToEmployeeAnswer(answer.getPlayerAnswer());
            }else{
                answeredEmployee_4 = true;
                chooseOptionbar.text = "";
                selectedObject.sprite = answeredSelectedSprite;
            }
        }
        
    }
    public void displayResponseToEmployeeAnswer(List<PlayerAnswer> answers) {
        if(selectedObject.name == "Employee_1") {
            answerOptions = answers;
            chooseOptionbar.text = answerOptions[answerIndex_1].getText();
        }
        if(selectedObject.name == "Employee_2") {
            answerOptions = answers;
            chooseOptionbar.text = answerOptions[answerIndex_2].getText();
        }
        if(selectedObject.name == "Employee_3") {
            answerOptions = answers;
            chooseOptionbar.text = answerOptions[answerIndex_3].getText();
        }
        if(selectedObject.name == "Employee_4") {
            answerOptions = answers;
            chooseOptionbar.text = answerOptions[answerIndex_4].getText();
        }
    }

}