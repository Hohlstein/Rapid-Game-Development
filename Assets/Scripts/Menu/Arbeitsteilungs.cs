using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Arbeitsteiling : MonoBehaviour
{

    public TextMeshProUGUI NameText;
    public SmoothMove textParent;
    public Image avatar;
    public EmployeeInfo infoSource;

    public TextMeshProUGUI SumText;
    public PercentageBar CodingSkill;
    public PercentageBar GameDesignSkill;
    public PercentageBar GraphicDesignSkill;
    public PercentageBar SoundDesignSkill;
    public Slider CodingSlider;
    public Slider GameDesignSlider;
    public Slider GraphicDesignSlider;
    public Slider SoundDesignSlider;
    public TextMeshProUGUI CodingText;
    public TextMeshProUGUI GameDesignText;
    public TextMeshProUGUI GraphicDesignText;
    public TextMeshProUGUI SoundDesignText;
    private int numberOfPeople;
    public float textAnimationY;
    private int ID = 0;

    public Sprite notSelected;
    public Sprite selected;
    private Dictionary<int, float[]> assignedHours = new Dictionary<int, float[]>();
    private float maxTotalHours = 32; // Maximum total hours allowed
    private float remainingHours = 32;

    private float _2Value = 1.5f;



    private Button[] buttons;


    public void Start()
    {
        NameText.text = "NAME HERE";
        ID = 0;




        CodingSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(CodingSlider.value, CodingSlider); });
        GameDesignSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(GameDesignSlider.value, GameDesignSlider); });
        GraphicDesignSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(GraphicDesignSlider.value, GraphicDesignSlider); });
        SoundDesignSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(SoundDesignSlider.value, SoundDesignSlider); });



        buttons = GetComponentsInChildren<Button>();

        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList FinalizedEmployeeHireList = obj.GetComponent<FinalizeEmployeeList>();
        List<Mitarbeiter> workers = FinalizedEmployeeHireList.GetEmployeeList();

        Dictionary<int, string> map = new Dictionary<int, string>();
        foreach (var worker in workers)
        {
            var w = worker.GetComponent<Mitarbeiter>();
            int id = w.getID();

            if (!map.ContainsKey(id)) // Check if the key already exists
            {
                map.Add(id, w.getFirstName() + " " + w.getLastName()[0] + ".");
                ID = id;
            }
        }

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => SelectButton(button));
            var id = button.GetComponent<ButtonsID>();
            if (id != null)
            {
                button.onClick.AddListener(() => ChangeID(id.ID));
                SetCorrectName(button, map);

                if (id.ID == ID)
                {
                    SelectButton(button);
                }
            }
        }

        GameObject object2 = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList FinalizedEmployeeHireList2 = object2.GetComponent<FinalizeEmployeeList>();
        Mitarbeiter current_employee = FinalizedEmployeeHireList2.GetEmployee(ID);
        maxTotalHours = current_employee.getWorkingHours();

        CodingSlider.minValue = 0;
        GameDesignSlider.minValue = 0;
        GraphicDesignSlider.minValue = 0;
        SoundDesignSlider.minValue = 0;

        CodingSlider.maxValue = maxTotalHours;
        GameDesignSlider.maxValue = maxTotalHours;
        GraphicDesignSlider.maxValue = maxTotalHours;
        SoundDesignSlider.maxValue = maxTotalHours;

        UpdateTexts(maxTotalHours);
    }


    private void SetCorrectName(Button button, Dictionary<int, string> map)
    {
        if (map.Count > 0)
        {
            var firstKeyValue = map.First();
            int firstKey = firstKeyValue.Key;
            string firstName = firstKeyValue.Value;

            map.Remove(firstKey);

            var id = button.GetComponent<ButtonsID>();
            if (id != null)
            {
                id.ID = firstKey;
            }

            var textMeshProUGUI = button.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshProUGUI != null)
            {
                textMeshProUGUI.SetText(firstName);
            }
        }
    }


    private void SelectButton(Button selectedButton)
    {
        if (selectedButton.GetComponent<ButtonsID>() == null)
            return;

        foreach (Button button in buttons)
        {
            if (button.GetComponent<ButtonsID>() == null)
                continue;

            Image buttonImage = button.GetComponent<Image>();
            buttonImage.sprite = notSelected;
        }

        Image selectedButtonImage = selectedButton.GetComponent<Image>();
        selectedButtonImage.sprite = selected;
    }

    public void Update()
    {
        //SnapSliderValues(CodingSlider, new float[] { 0, _2Value, 4, 6, 32 });
        //SnapSliderValues(GameDesignSlider, new float[] { 0, _2Value, 4, 6, 32 });
        //SnapSliderValues(GraphicDesignSlider, new float[] { 0, _2Value, 4, 6, 32 });
        //SnapSliderValues(SoundDesignSlider, new float[] { 0, _2Value, 4, 6, 32 });

        UpdateDisplayedValues();
    }

    public void ChangeID(int newID)
    {
        numberOfPeople = 8;
        if (newID >= 0 && newID < numberOfPeople)
        {
            // Vor dem Wechseln des Mitarbeiters die Slider auf 0 setzen
            CodingSlider.value = 0;
            GameDesignSlider.value = 0;
            GraphicDesignSlider.value = 0;
            SoundDesignSlider.value = 0;
            ID = newID;
            GameObject object2 = GameObject.Find("FinalizedHiredEmployeeList");
            FinalizeEmployeeList FinalizedEmployeeHireList2 = object2.GetComponent<FinalizeEmployeeList>();
            Mitarbeiter current_employee = FinalizedEmployeeHireList2.GetEmployee(ID);
            maxTotalHours = current_employee.getWorkingHours();

            CodingSlider.minValue = 0;
            GameDesignSlider.minValue = 0;
            GraphicDesignSlider.minValue = 0;
            SoundDesignSlider.minValue = 0;

            CodingSlider.maxValue = maxTotalHours;
            GameDesignSlider.maxValue = maxTotalHours;
            GraphicDesignSlider.maxValue = maxTotalHours;
            SoundDesignSlider.maxValue = maxTotalHours;

            UpdateTexts(maxTotalHours);
            LoadAssignedHours(ID);
        }
        animateUIElements();
        UpdateDisplayedValues();
    }


    private void animateUIElements()
    {
        CodingSkill.setCurrentVal(0);
        GameDesignSkill.setCurrentVal(0);
        GraphicDesignSkill.setCurrentVal(0);
        SoundDesignSkill.setCurrentVal(0);
        LoadAssignedHours(ID);
        //textParent.setCurrentY(textAnimationY);

        CodingSkill.setCurrentVal(GetAssignedHours(ID, "Coding"));
        GameDesignSkill.setCurrentVal(GetAssignedHours(ID, "GameDesign"));
        GraphicDesignSkill.setCurrentVal(GetAssignedHours(ID, "GraphicDesign"));
        SoundDesignSkill.setCurrentVal(GetAssignedHours(ID, "SoundDesign"));
    }

    private void UpdateDisplayedValues()
    {
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList FinalizedEmployeeHireList = obj.GetComponent<FinalizeEmployeeList>();
        Mitarbeiter current_employee = FinalizedEmployeeHireList.GetEmployee(ID);


        NameText.text = current_employee.getFirstName() + " " + current_employee.getLastName()[0] + ".";



        FindObjectOfType<AvatarManager>().SetEmployee(current_employee);



        CodingSkill.setTargetVal(current_employee.getCodingSkill());
        GraphicDesignSkill.setTargetVal(current_employee.getGraphicDesignSkill());
        GameDesignSkill.setTargetVal(current_employee.getGameDesignSkill());
        SoundDesignSkill.setTargetVal(current_employee.getSoundDesignSkill());

    }

    public int GetCurrentID()
    {
        return ID;
    }

    public void SetSumOfSliderValues()
    {
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList FinalizedEmployeeHireList = obj.GetComponent<FinalizeEmployeeList>();
        Mitarbeiter current_employee = FinalizedEmployeeHireList.GetEmployee(ID);

        float coding = CodingSlider.value;
        float gameDesign = GameDesignSlider.value;
        float graphic = GraphicDesignSlider.value;
        float sound = SoundDesignSlider.value;

        if (coding == _2Value)
            coding = 2.0f;
        if (gameDesign == _2Value)
            gameDesign = 2.0f;
        if (graphic == _2Value)
            graphic = 2.0f;
        if (sound == _2Value)
            sound = 2.0f;

        float sum = coding + gameDesign + graphic + sound;
        current_employee.setWorkinghours((int)sum);
        current_employee.SetgraphicDesignHours((int)graphic);
        current_employee.SetcodingHours((int)coding);
        current_employee.SetgameDesignHours((int)gameDesign);
        current_employee.SetsoundDesignHours((int)sound);

        SaveAssignedHours(ID, "Coding", CodingSlider.value);
        SaveAssignedHours(ID, "GameDesign", GameDesignSlider.value);
        SaveAssignedHours(ID, "GraphicDesign", GraphicDesignSlider.value);
        SaveAssignedHours(ID, "SoundDesign", SoundDesignSlider.value);
    }

    private void SnapSliderValues(Slider slider, float[] snapValues)
    {
        float closestSnapValue = snapValues[0];
        float closestDistance = Mathf.Abs(slider.value - snapValues[0]);

        foreach (float snapValue in snapValues)
        {
            float distance = Mathf.Abs(slider.value - snapValue);
            if (distance < closestDistance)
            {
                closestSnapValue = snapValue;
                closestDistance = distance;
            }
        }

        slider.value = closestSnapValue;
    }

    private void UpdateSumText()
    {
        float coding = CodingSlider.value;
        float gameDesign = GameDesignSlider.value;
        float graphic = GraphicDesignSlider.value;
        float sound = SoundDesignSlider.value;

        float sum = coding + gameDesign + graphic + sound;

        if (sum > maxTotalHours)
        {
            float overflow = sum - maxTotalHours;

            // Distribute the overflow back to the sliders
            float adjustment = overflow / 4;
            coding -= adjustment;
            gameDesign -= adjustment;
            graphic -= adjustment;
            sound -= adjustment;

            // Make sure the values are within bounds
            coding = Mathf.Clamp(coding, 0, maxTotalHours);
            gameDesign = Mathf.Clamp(gameDesign, 0, maxTotalHours);
            graphic = Mathf.Clamp(graphic, 0, maxTotalHours);
            sound = Mathf.Clamp(sound, 0, maxTotalHours);
        }

        CodingSlider.value = coding;
        GameDesignSlider.value = gameDesign;
        GraphicDesignSlider.value = graphic;
        SoundDesignSlider.value = sound;

        SumText.text = sum.ToString();
    }




    private void LoadAssignedHours(int employeeID)
    {
        if (assignedHours.ContainsKey(employeeID))
        {
            float[] hours = assignedHours[employeeID];
            CodingSlider.value = hours[0];
            GameDesignSlider.value = hours[1];
            GraphicDesignSlider.value = hours[2];
            SoundDesignSlider.value = hours[3];
        }
        else
        {
            CodingSlider.value = 0;
            GameDesignSlider.value = 0;
            GraphicDesignSlider.value = 0;
            SoundDesignSlider.value = 0;
        }
    }

    private void SaveAssignedHours(int employeeID, string category, float hours)
    {
        if (!assignedHours.ContainsKey(employeeID))
        {
            assignedHours.Add(employeeID, new float[4]);
        }

        switch (category)
        {
            case "Coding":
                assignedHours[employeeID][0] = hours;
                break;
            case "GameDesign":
                assignedHours[employeeID][1] = hours;
                break;
            case "GraphicDesign":
                assignedHours[employeeID][2] = hours;
                break;
            case "SoundDesign":
                assignedHours[employeeID][3] = hours;
                break;
        }
    }

    private float GetAssignedHours(int employeeID, string category)
    {
        if (assignedHours.ContainsKey(employeeID))
        {
            switch (category)
            {
                case "Coding":
                    return assignedHours[employeeID][0];
                case "GameDesign":
                    return assignedHours[employeeID][1];
                case "GraphicDesign":
                    return assignedHours[employeeID][2];
                case "SoundDesign":
                    return assignedHours[employeeID][3];
            }
        }

        return 0;
    }

    private void OnSliderValueChanged(float newValue, Slider slider)
    {
        float totalValue = CodingSlider.value + GameDesignSlider.value + GraphicDesignSlider.value + SoundDesignSlider.value;

        if (totalValue > maxTotalHours)
        {
            float excessValue = totalValue - maxTotalHours;
            float adjustedValue = newValue - excessValue;
            slider.value = adjustedValue;
        }

        int sum = (int)CodingSlider.value + (int)GameDesignSlider.value + (int)GraphicDesignSlider.value + (int)SoundDesignSlider.value;
        SumText.text = sum.ToString("F0"); // Display as a whole number without decimal places
        Debug.Log("dsgfsdf" + sum);
    }

    private void UpdateTexts(float remainingHours)
    {
        CodingText.text = $"{remainingHours:F0}h";
        GameDesignText.text = $"{remainingHours * 0.75:F0}h";
        GraphicDesignText.text = $"{remainingHours * 0.5:F0}h";
        SoundDesignText.text = $"{(remainingHours * 0.25):F0}h";
    }
}

