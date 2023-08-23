/*
Author: Fabian Wiehn
*/
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System;

public class Select_DisplayEmployeeChat : MonoBehaviour{
    public List<TextMeshProUGUI> employeeNames;
    private List<Mitarbeiter> Hired_Employee_Objects;

    public GameObject ok_button; 
    public GameObject tutorialText;

    public Image selectedObject; //tracks currently selected sprite
    //Holders for the different sprites needed when selecting/deselecting
    public Sprite selectedSprite;
    public Sprite defaultSprite;
    public Sprite answeredSelectedSprite;
    public Sprite answeredSprite;

    public TextMeshProUGUI selectedEmployeeName;
    public GameObject totalHours;
    //Prefabs for the send and recieve Text bubbles
    public GameObject recievedPrefab;
    public GameObject sentPrefab;
    
    private bool answeredEmployee_1; //tracks if employee has been answered completely
    public GameObject chatHolder_1; 
    public ScrollRect scrollRect_1;
    public GameObject chatScrollRect_1;
    private bool messageRecieved_1; //tracks whether a message has already been recieved from this employee
    private DialogueNode dialogue_1; //sets which dialogue is used from the dialogue list
    private int answerIndex_1; //sets which answer option is currently displayed
    private int answeredAmount_1; //tracks how many answers have been sent to properly set position of text bubbles
    private List<PlayerAnswer> currentAnswers_1; //tracks the current answers so you can switch between chats at any time

    public GameObject chatScrollRect_2;
    public GameObject chatHolder_2;
    public ScrollRect scrollRect_2;
    private bool messageRecieved_2;
    private bool answeredEmployee_2;
    private DialogueNode dialogue_2;
    private int answerIndex_2;
    private int answeredAmount_2;
    private List<PlayerAnswer> currentAnswers_2;

    public AvatarManager avatar1;
    public AvatarManager avatar2;
    public AvatarManager avatar3;
    public AvatarManager avatar4;

    public GameObject chatScrollRect_3;
    public GameObject chatHolder_3;
    public ScrollRect scrollRect_3;
    private bool messageRecieved_3;
    private bool answeredEmployee_3;
    private DialogueNode dialogue_3;
    private int answerIndex_3;
    private int answeredAmount_3;
    private List<PlayerAnswer> currentAnswers_3;

    public GameObject chatScrollRect_4;
    public GameObject chatHolder_4;
    public ScrollRect scrollRect_4;
    private bool messageRecieved_4;
    private bool answeredEmployee_4;
    private DialogueNode dialogue_4;
    private int answerIndex_4;
    private int answeredAmount_4;
    private List<PlayerAnswer> currentAnswers_4;

    private List<PlayerAnswer> answerOptions; //holds all current answer options
    public GameObject chooseOptionbarParent;
    public TextMeshProUGUI chooseOptionbar;

    public Rng rng;
    
    //Finds HiredEmployeeList and deactivates all fields that shouldnt be seen yet
    void Start() {
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();

        UpdateTextFields();
        scrollRect_1.verticalNormalizedPosition = 1f;
        scrollRect_2.verticalNormalizedPosition = 1f;
        scrollRect_3.verticalNormalizedPosition = 1f;
        scrollRect_4.verticalNormalizedPosition = 1f;

        selectedEmployeeName.enabled = false;
        totalHours.SetActive(false);
        ok_button.SetActive(false);
        chatScrollRect_1.SetActive(false);
        chatScrollRect_2.SetActive(false);
        chatScrollRect_3.SetActive(false);
        chatScrollRect_4.SetActive(false);

        chooseOptionbarParent.SetActive(false);

        answeredEmployee_1 = false;
        answeredEmployee_2 = false;
        answeredEmployee_3 = false;
        answeredEmployee_4 = false;
        totalHours.GetComponentInChildren<TextMeshProUGUI>().text = "";
        
    }

    private void UpdateAvatarFields() {
        avatar1.SetEmployee(Hired_Employee_Objects[0]);
        avatar2.SetEmployee(Hired_Employee_Objects[1]);
        avatar3.SetEmployee(Hired_Employee_Objects[2]);
        avatar4.SetEmployee(Hired_Employee_Objects[3]);
    }
    
    void Update() {
        checkIfAllAnswered();
        updateTotalHoursField();
        UpdateAvatarFields();
    }

    //Updates the totalhours shown for the selected employee
    private void updateTotalHoursField(){
        if(selectedObject.name == "Employee_1"){
            totalHours.GetComponentInChildren<TextMeshProUGUI>().text ="Total Hours: "+ Hired_Employee_Objects[0].getWorkingHours()+"";
        }
        if(selectedObject.name == "Employee_2"){
            totalHours.GetComponentInChildren<TextMeshProUGUI>().text ="Total Hours: "+ Hired_Employee_Objects[1].getWorkingHours()+"";
        }
        if(selectedObject.name == "Employee_3"){
            totalHours.GetComponentInChildren<TextMeshProUGUI>().text ="Total Hours: "+ Hired_Employee_Objects[2].getWorkingHours()+"";
        }
        if(selectedObject.name == "Employee_4"){
            totalHours.GetComponentInChildren<TextMeshProUGUI>().text ="Total Hours: "+ Hired_Employee_Objects[3].getWorkingHours()+"";
        }
    }

    //Displays all the employees' names on the corresponding field in the scene
    private void UpdateTextFields() {
        foreach(TextMeshProUGUI employeeName in employeeNames) {
            employeeName.text = "temp";
        }
        int index = 0;
        foreach(Mitarbeiter hired in Hired_Employee_Objects) {
                employeeNames[index].text = hired.getFirstName() + " " + hired.getLastName();
                index++; 
       }
    }
    //Checks if all employees have been answered, if true it displays the ok button to switch to next scene
    private void checkIfAllAnswered() {
        ok_button.SetActive(false);
        if(answeredEmployee_1 == true){
            if(answeredEmployee_2 == true) {
                if(answeredEmployee_3 == true) {
                    if(answeredEmployee_4 == true) {
                        tutorialText.SetActive(false);
                        ok_button.SetActive(true);
                    }
                }
            }
        }
    }
    //Checks which employee has been clicked anmd displays the name on top of the chat, also activates the corresponding chat panel
    public void DisplaySelectedName(GameObject clickedObject) {
        totalHours.SetActive(true);
        Transform findName;
        selectedEmployeeName.enabled = true;
        if(clickedObject.name == "Employee_1") {
            findName = clickedObject.transform.Find("employee_1_name");
            string buttonText = findName.GetComponent<TextMeshProUGUI>().text; 
            selectedEmployeeName.text = buttonText;
            chooseOptionbarParent.SetActive(true);
            totalHours.GetComponentInChildren<TextMeshProUGUI>().text ="Total Hours: "+ Hired_Employee_Objects[0].getWorkingHours()+"";
            Debug.Log("HiredEmployeeObject_1 "+ Hired_Employee_Objects[0].getFirstName() + Hired_Employee_Objects[0].getLastName());
        }
        if(clickedObject.name == "Employee_2") {
            findName = clickedObject.transform.Find("employee_2_name");
            string buttonText = findName.GetComponent<TextMeshProUGUI>().text; 
            selectedEmployeeName.text = buttonText;
            chooseOptionbarParent.SetActive(true);
            totalHours.GetComponentInChildren<TextMeshProUGUI>().text ="Total Hours: "+ Hired_Employee_Objects[1].getWorkingHours()+"";
            Debug.Log("HiredEmployeeObject_2"+ Hired_Employee_Objects[1].getFirstName() + Hired_Employee_Objects[1].getLastName() );
        }
        if(clickedObject.name == "Employee_3") {
            findName = clickedObject.transform.Find("employee_3_name");
            string buttonText = findName.GetComponent<TextMeshProUGUI>().text; 
            selectedEmployeeName.text = buttonText;
            chooseOptionbarParent.SetActive(true);
            totalHours.GetComponentInChildren<TextMeshProUGUI>().text ="Total Hours: "+ Hired_Employee_Objects[2].getWorkingHours()+"";
            Debug.Log("HiredEmployeeObject_3 "+ Hired_Employee_Objects[2].getFirstName()+ Hired_Employee_Objects[2].getLastName());
        }
        if(clickedObject.name == "Employee_4") {
            findName = clickedObject.transform.Find("employee_4_name");
            string buttonText = findName.GetComponent<TextMeshProUGUI>().text; 
            selectedEmployeeName.text = buttonText;
            chooseOptionbarParent.SetActive(true);
            totalHours.GetComponentInChildren<TextMeshProUGUI>().text ="Total Hours: "+ Hired_Employee_Objects[3].getWorkingHours()+"";
            Debug.Log("HiredEmployeeObject_4 "+ Hired_Employee_Objects[3].getFirstName()+ Hired_Employee_Objects[3].getLastName());
        }
        
    }
    //Bug: If answered then deselected and reselected answeredSprite isnt showing normal one is showing instead
    //Changes the sprite of the selected Employee 
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
            if(answeredEmployee_1 == true) {
                chatScrollRect_1.SetActive(true);
                clickedObject.sprite = answeredSelectedSprite;
            }
            chatScrollRect_1.SetActive(true);
            if(messageRecieved_1 == false) {
                recieveMessage_1();
            }
            
        }
        if(clickedObject.name == "Employee_2") {
            if(answeredEmployee_2 == true) {
                chatScrollRect_2.SetActive(true);
                clickedObject.sprite = answeredSelectedSprite;
            }
            chatScrollRect_2.SetActive(true);
            if(messageRecieved_2 == false) {
                recieveMessage_2();
            }
           
        }
        if(clickedObject.name == "Employee_3") {
            if(answeredEmployee_3 == true) {
                chatScrollRect_3.SetActive(true);
                clickedObject.sprite = answeredSelectedSprite;
            }
            chatScrollRect_3.SetActive(true);
            if(messageRecieved_3 == false) {
                recieveMessage_3();
            }
            
        }
        if(clickedObject.name == "Employee_4") {
            if(answeredEmployee_4 == true) {
                chatScrollRect_4.SetActive(true);
                clickedObject.sprite = answeredSelectedSprite;
            }
            chatScrollRect_4.SetActive(true);
            if(messageRecieved_4 == false) {
                recieveMessage_4();
            }
            
        }
    }
    //Resets the selected buttons' sprite once it is deselected 
    private void ResetButton()
    {
        selectedObject.sprite = defaultSprite;
        if(selectedObject.name == "Employee_1" ){
            if(answeredEmployee_1 == true) {
            selectedObject.sprite = answeredSprite;
            chatScrollRect_1.SetActive(false);
            }
        }

        if(selectedObject.name == "Employee_2"){
            if(answeredEmployee_2 == true) {
            selectedObject.sprite = answeredSprite;
            chatScrollRect_2.SetActive(false);
            }
        }

        if(selectedObject.name == "Employee_3"){
            if(answeredEmployee_3 == true) {
                selectedObject.sprite = answeredSprite;
                chatScrollRect_3.SetActive(false);
            }
        }
        if(selectedObject.name == "Employee_4"){
            if(answeredEmployee_4 == true) {
            selectedObject.sprite = answeredSprite;
            chatScrollRect_4.SetActive(false);
            }
        } 
    }

    //Sends the according message to employee 1 chat panel, also displays the first option in your send bar
    private void recieveMessage_1() {
        answeredAmount_1=0;
        dialogue_1= rng.getRandomDialogueOption(Hired_Employee_Objects[0]); 
        messageRecieved_1 = true;
        GameObject recievedText_1 = Instantiate(recievedPrefab, chatHolder_1.transform);

        recievedText_1.GetComponentInChildren<TextMeshProUGUI>().text = dialogue_1.getText();
        if(dialogue_1.getFinalNode() == true) {
            answeredEmployee_1 = true;
            clearAnswerOptions();
        }else{
            answerOptions = dialogue_1.getPlayerAnswer();
            chooseOptionbar.text = answerOptions[answerIndex_1].getText();
        }
    }
    //Sends the according message to employee 2 chat panel, also displays the first option in your send bar
    private void recieveMessage_2() {
        answeredAmount_2=0;
        dialogue_2 = rng.getRandomDialogueOption(Hired_Employee_Objects[1]); 
        messageRecieved_2 = true;
        GameObject recievedText_2 = Instantiate(recievedPrefab, chatHolder_2.transform);

        recievedText_2.GetComponentInChildren<TextMeshProUGUI>().text = dialogue_2.getText();
        if(dialogue_2.getFinalNode() == true) {
            answeredEmployee_2 = true;
            clearAnswerOptions();
        }else{
            answerOptions = dialogue_2.getPlayerAnswer();
            chooseOptionbar.text = answerOptions[answerIndex_2].getText();
        }
    }
    //Sends the according message to employee 3 chat panel, also displays the first option in your send bar
    private void recieveMessage_3() {
        answeredAmount_3=0;
        dialogue_3 = rng.getRandomDialogueOption(Hired_Employee_Objects[2]); 
        messageRecieved_3 = true;
        GameObject recievedText_3 = Instantiate(recievedPrefab, chatHolder_3.transform);

        recievedText_3.GetComponentInChildren<TextMeshProUGUI>().text = dialogue_3.getText();
        if(dialogue_3.getFinalNode() == true) {
            answeredEmployee_3 = true;
            clearAnswerOptions();
        }else{
            answerOptions = dialogue_3.getPlayerAnswer();
            chooseOptionbar.text = answerOptions[answerIndex_3].getText();
        }
    }
    //Sends the according message to employee 4 chat panel, also displays the first option in your send bar
    private void recieveMessage_4() {
        answeredAmount_4=0;
        dialogue_4 = rng.getRandomDialogueOption(Hired_Employee_Objects[3]); 
        messageRecieved_4 = true;
        GameObject recievedText_4 = Instantiate(recievedPrefab, chatHolder_4.transform);

        recievedText_4.GetComponentInChildren<TextMeshProUGUI>().text = dialogue_4.getText();
        if(dialogue_4.getFinalNode() == true) {
            answeredEmployee_4 = true;
            clearAnswerOptions();
        }else{
            answerOptions = dialogue_4.getPlayerAnswer();
            chooseOptionbar.text = answerOptions[answerIndex_4].getText();
        }
    }
    //Displays the different answeroptions on different chat panels depending on selectedObject on your chat bar.
    //Called by Down Button on click
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
    //Displays the different answeroptions for different chat panels depending on selectedObject on your chat bar. 
    //Called by Up Button on click
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
    private void clearAnswerOptions(){
        if(answerOptions != null ){
            answerOptions.Clear();
            chooseOptionbar.text = "";
        }
    }
    //Checks which employee is selected and sends the corresponding answer, checks if it was the last dialogue node if yes it clears option bar 
    //and disables any send Functions
    public void sendAnswer() {
        if(selectedObject.name == "Employee_1") {
            if(answeredEmployee_1 != true) {
                if(answeredAmount_1 == 0) {
                                    //Maybe Here
                    answerOptions = dialogue_1.getPlayerAnswer();
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
                        adjustEmployeeValuesAfterPlayerResponse();
                    }
                }else{
                    GameObject sentText_1 = Instantiate(sentPrefab, chatHolder_1.transform);
                    for (int i = 0; i < answeredAmount_1; i++){
                        sentText_1.transform.position = sentText_1.transform.position- new Vector3(0f,450f);
                    }
                    sentText_1.GetComponentInChildren<TextMeshProUGUI>().text = chooseOptionbar.text;
                    answeredAmount_1++;
                    if(answerOptions[answerIndex_1].getFinalNode() == false) {
                        sendEmployeeAnswer(answerOptions[answerIndex_1].getNextNode());
                    }else{
                        answeredEmployee_1 = true;
                        chooseOptionbar.text = ""; 
                        selectedObject.sprite = answeredSelectedSprite;
                        adjustEmployeeValuesAfterPlayerResponse();
                    }
                }  
            }
        }

        if(selectedObject.name == "Employee_2") {
            if(answeredEmployee_2 != true) {
                if(answeredAmount_2 == 0) {
                    answerOptions = dialogue_2.getPlayerAnswer();
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
                        adjustEmployeeValuesAfterPlayerResponse();
                    }
                }else{
                    GameObject sentText_2 = Instantiate(sentPrefab, chatHolder_2.transform);
                    for (int i = 0; i < answeredAmount_2; i++){
                        sentText_2.transform.position = sentText_2.transform.position- new Vector3(0f,450f);
                    }
                    sentText_2.GetComponentInChildren<TextMeshProUGUI>().text = chooseOptionbar.text;
                    answeredAmount_2++;
                    if(answerOptions[answerIndex_2].getFinalNode() == false) {
                        sendEmployeeAnswer(answerOptions[answerIndex_2].getNextNode());
                    }else{
                        answeredEmployee_2 = true;
                        chooseOptionbar.text = "";
                        selectedObject.sprite = answeredSelectedSprite;
                        adjustEmployeeValuesAfterPlayerResponse();
                    }
                }  
            }
        }
        if(selectedObject.name == "Employee_3") {
            if(answeredEmployee_3 != true) {
                if(answeredAmount_3 == 0) {
                    answerOptions = dialogue_3.getPlayerAnswer();
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
                        adjustEmployeeValuesAfterPlayerResponse();
                    }
                }else{
                    GameObject sentText_3 = Instantiate(sentPrefab, chatHolder_3.transform);
                    for (int i = 0; i < answeredAmount_3; i++){
                        sentText_3.transform.position = sentText_3.transform.position- new Vector3(0f,450f);
                    }
                    sentText_3.GetComponentInChildren<TextMeshProUGUI>().text = chooseOptionbar.text;
                    answeredAmount_3++;
                    if(answerOptions[answerIndex_3].getFinalNode() == false) {
                        sendEmployeeAnswer(answerOptions[answerIndex_3].getNextNode());
                    }else{
                        answeredEmployee_3 = true;
                        chooseOptionbar.text = "";
                        selectedObject.sprite = answeredSelectedSprite;
                        adjustEmployeeValuesAfterPlayerResponse();
                    }
                }  
            }
        }
        if(selectedObject.name == "Employee_4") {
            if(answeredEmployee_4 != true) {
                if(answeredAmount_4 == 0) {
                    answerOptions = dialogue_4.getPlayerAnswer();
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
                        adjustEmployeeValuesAfterPlayerResponse();
                    }
                }else{
                    GameObject sentText_4 = Instantiate(sentPrefab, chatHolder_4.transform);
                    for (int i = 0; i < answeredAmount_4; i++){
                        sentText_4.transform.position = sentText_4.transform.position- new Vector3(0f,450f);
                    }
                    sentText_4.GetComponentInChildren<TextMeshProUGUI>().text = chooseOptionbar.text;
                    answeredAmount_4++;
                    if(answerOptions[answerIndex_4].getFinalNode() == false) {
                        sendEmployeeAnswer(answerOptions[answerIndex_4].getNextNode());
                    }else{
                        answeredEmployee_4 = true;
                        chooseOptionbar.text = "";
                        selectedObject.sprite = answeredSelectedSprite;
                        adjustEmployeeValuesAfterPlayerResponse();
                    }
                }  
            }
        }
    }
    //Checks which employee is currently selected to send the corresponding employeeAnswer to the before send playerAnswer
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
                adjustEmployeeValuesAfterEmployeeResponse(answer);
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
                adjustEmployeeValuesAfterEmployeeResponse(answer);
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
                adjustEmployeeValuesAfterEmployeeResponse(answer);
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
                adjustEmployeeValuesAfterEmployeeResponse(answer);
            }
        }  
    }
    //Displays the response options to the before recieved message from the employee on followup messages not on first recieved one
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

    //Adds to or substracts from working hours of employees depending on getWorkingHoursUp() bool.
    //WorkingHoursUp bool and and AmountOfHoursChanging is defined when creating dialogue trees in editor
    //!!!!!! Productivity and Relationship adjustments are NYI !!!!!!!
    private void adjustEmployeeValuesAfterPlayerResponse(){
        if(selectedObject.name == "Employee_1") {
            if(answerOptions[answerIndex_1].getAmountOfHoursChanging() == 0){

            }else{
                if(answerOptions[answerIndex_1].getWorkingHoursUp() == true) {
                Hired_Employee_Objects[0].setWorkinghours(Hired_Employee_Objects[0].getWorkingHours() + answerOptions[answerIndex_1].getAmountOfHoursChanging());
                }
                if(answerOptions[answerIndex_1].getWorkingHoursUp() == false) {
                    Hired_Employee_Objects[0].setWorkinghours(Hired_Employee_Objects[0].getWorkingHours() - answerOptions[answerIndex_1].getAmountOfHoursChanging());
                }
            } 
        }

        if(selectedObject.name == "Employee_2") {
            if(answerOptions[answerIndex_2].getAmountOfHoursChanging() == 0){

            }else{
                if(answerOptions[answerIndex_2].getWorkingHoursUp() == true) {
                    Hired_Employee_Objects[1].setWorkinghours(Hired_Employee_Objects[1].getWorkingHours() + answerOptions[answerIndex_2].getAmountOfHoursChanging());
                }
                if(answerOptions[answerIndex_2].getWorkingHoursUp() == false) {
                    Hired_Employee_Objects[1].setWorkinghours(Hired_Employee_Objects[1].getWorkingHours() - answerOptions[answerIndex_2].getAmountOfHoursChanging());
                } 
            }
        }

        if(selectedObject.name == "Employee_3") {
            if(answerOptions[answerIndex_3].getAmountOfHoursChanging() == 0){

            }else{
                if(answerOptions[answerIndex_3].getWorkingHoursUp() == true) {
                    Hired_Employee_Objects[2].setWorkinghours(Hired_Employee_Objects[2].getWorkingHours() + answerOptions[answerIndex_3].getAmountOfHoursChanging());
                }
                if(answerOptions[answerIndex_3].getWorkingHoursUp() == false) {
                    Hired_Employee_Objects[2].setWorkinghours(Hired_Employee_Objects[2].getWorkingHours() - answerOptions[answerIndex_3].getAmountOfHoursChanging());
                }
            }
        }

        if(selectedObject.name == "Employee_4") {
            if(answerOptions[answerIndex_4].getAmountOfHoursChanging() == 0){
                
            }else{
                if(answerOptions[answerIndex_4].getWorkingHoursUp() == true) {
                    Hired_Employee_Objects[3].setWorkinghours(Hired_Employee_Objects[3].getWorkingHours() + answerOptions[answerIndex_4].getAmountOfHoursChanging());
                }
                if(answerOptions[answerIndex_4].getWorkingHoursUp() == false) {
                    Hired_Employee_Objects[3].setWorkinghours(Hired_Employee_Objects[3].getWorkingHours() - answerOptions[answerIndex_4].getAmountOfHoursChanging());
                } 
            }
        }
    }

    private void adjustEmployeeValuesAfterEmployeeResponse(DialogueNode employeeResponse){
        if(selectedObject.name == "Employee_1") {
            if(employeeResponse.getAmountOfHoursChanging() == 0) {

            }else{
                if(employeeResponse.getWorkingHoursUp() == true) {
                    Hired_Employee_Objects[0].setWorkinghours(Hired_Employee_Objects[0].getWorkingHours() + employeeResponse.getAmountOfHoursChanging());
                }
                if(employeeResponse.getWorkingHoursUp() == false) {
                    Hired_Employee_Objects[0].setWorkinghours(Hired_Employee_Objects[0].getWorkingHours() - employeeResponse.getAmountOfHoursChanging());
                } 
            }
        }
        if(selectedObject.name == "Employee_2") {
            if(employeeResponse.getAmountOfHoursChanging() == 0) {

            }else{
                if(employeeResponse.getWorkingHoursUp() == true) {
                    Hired_Employee_Objects[1].setWorkinghours(Hired_Employee_Objects[1].getWorkingHours() + employeeResponse.getAmountOfHoursChanging());
                }
                if(employeeResponse.getWorkingHoursUp() == false) {
                    Hired_Employee_Objects[1].setWorkinghours(Hired_Employee_Objects[1].getWorkingHours() - employeeResponse.getAmountOfHoursChanging());
                } 
            }
        }
        if(selectedObject.name == "Employee_3") {
            if(employeeResponse.getAmountOfHoursChanging() == 0) {

            }else{
                if(employeeResponse.getWorkingHoursUp() == true) {
                    Hired_Employee_Objects[2].setWorkinghours(Hired_Employee_Objects[2].getWorkingHours() + employeeResponse.getAmountOfHoursChanging());
                }
                if(employeeResponse.getWorkingHoursUp() == false) {
                    Hired_Employee_Objects[2].setWorkinghours(Hired_Employee_Objects[2].getWorkingHours() - employeeResponse.getAmountOfHoursChanging());
                } 
            }
        }
        if(selectedObject.name == "Employee_4") {
            if(employeeResponse.getAmountOfHoursChanging() == 0) {

            }else{
                if(employeeResponse.getWorkingHoursUp() == true) {
                    Hired_Employee_Objects[3].setWorkinghours(Hired_Employee_Objects[3].getWorkingHours() + employeeResponse.getAmountOfHoursChanging());
                }
                if(employeeResponse.getWorkingHoursUp() == false) {
                    Hired_Employee_Objects[3].setWorkinghours(Hired_Employee_Objects[3].getWorkingHours() - employeeResponse.getAmountOfHoursChanging());
                } 
            }
        }
    }
}