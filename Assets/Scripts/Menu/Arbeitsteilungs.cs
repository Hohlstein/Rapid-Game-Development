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
    private int numberOfPeople;
    public float textAnimationY;
    private int ID = 0;

    public Sprite notSelected;
    public Sprite selected;


    private float _2Value = 1.5f;



    private Button[] buttons;


    public void Start()
    {
        NameText.text = "NAME HERE";
        ID = 0;

        CodingSlider.minValue = 0;
        GameDesignSlider.minValue = 0;
        GraphicDesignSlider.minValue = 0;
        SoundDesignSlider.minValue = 0;

        CodingSlider.maxValue = 8;
        GameDesignSlider.maxValue = 8;
        GraphicDesignSlider.maxValue = 8;
        SoundDesignSlider.maxValue = 8;


        CodingSlider.onValueChanged.AddListener((value) => UpdateSumText());
        GameDesignSlider.onValueChanged.AddListener((value) => UpdateSumText());
        GraphicDesignSlider.onValueChanged.AddListener((value) => UpdateSumText());
        SoundDesignSlider.onValueChanged.AddListener((value) => UpdateSumText());

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
        SnapSliderValues(CodingSlider, new float[] { 0, _2Value, 4, 6, 8 });
        SnapSliderValues(GameDesignSlider, new float[] { 0, _2Value, 4, 6, 8 });
        SnapSliderValues(GraphicDesignSlider, new float[] { 0, _2Value, 4, 6, 8 });
        SnapSliderValues(SoundDesignSlider, new float[] { 0, _2Value, 4, 6, 8 });

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
        //textParent.setCurrentY(textAnimationY);
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

        if (coding == _2Value)
            coding = 2.0f;
        if (gameDesign == _2Value)
            gameDesign = 2.0f;
        if (graphic == _2Value)
            graphic = 2.0f;
        if (sound == _2Value)
            sound = 2.0f;



        float sum = coding + gameDesign + graphic + sound;
        SumText.text = sum.ToString();
    }


}