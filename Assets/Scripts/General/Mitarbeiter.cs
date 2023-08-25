using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mitarbeiter : MonoBehaviour
{
      [SerializeField]
    private int ID;
      [SerializeField]
    private string firstName;
      [SerializeField]
    private string lastName;
    [SerializeField]
    private string nickName;
      [SerializeField]
    private int age;
      [SerializeField]
    private string relationshipStatus;
      [SerializeField]
    private string bio;
      [SerializeField]
    private int codingSkill;
      [SerializeField]
    private int gameDesignSkill;
      [SerializeField]
    private int GraphicDesignSkill;
      [SerializeField]
    private int soundDesignSkill;
      [SerializeField]
    private int stresslevel;
      [SerializeField]
    private int workinghours;
      [SerializeField]
    private int codingHours;
      [SerializeField]
    private int gameDesignHours;
      [SerializeField]
    private int graphicDesignHours;
      [SerializeField]
    private int soundDesignHours;
    [SerializeField]
    private Sprite profile_picture;
    [SerializeField]
    private bool CategoryHoursAssigned;
    private bool problemCharacter;


 
    // Start is called before the first frame update
    void Start()
    
    {        
        DontDestroyOnLoad(this.gameObject);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getID(){
        return this.ID;
    }

    public string getFirstName(){
        return this.firstName;
    }
    public string getLastName(){
        return this.lastName;
    }
    public string getNickName(){
        return this.nickName;
    }
    public int getAge(){
        return this.age;
    }
    public string getRelationshipStatus(){
        return this.relationshipStatus;
    }
    public string getBio(){
        return this.bio;
    }
    public int getCodingSkill(){
        return this.codingSkill;
    }
    public int getGameDesignSkill(){
        return this.gameDesignSkill;
    }
    public int getGraphicDesignSkill(){
        return this.GraphicDesignSkill;
    }
    public int getSoundDesignSkill(){
        return this.soundDesignSkill;
    }
    public int getStressLevel(){
        return this.stresslevel;
    }
    public int getWorkingHours(){
        return this.workinghours;
    }
    public int getCodingHours(){
        return this.codingHours;
    }
    public int getGameDesignHours(){
        return this.gameDesignHours;
    }
    public int getGrapicDesignHours(){
        return this.graphicDesignHours;
    }
    public int getSoundDesignHours(){
        return this.soundDesignHours;
    }

    public int getStressed(int stress)
    {
        this.stresslevel += stress;
        return this.stresslevel;
    }

    public void removeStress(int stress) {
      this.stresslevel -= stress;
    }

    public void setWorkinghours(int value)
    {
        workinghours = value;
        CategoryHoursAssigned = true;
    }
    public void SetcodingHours(int value)
    {
        codingHours = value;
        CategoryHoursAssigned = true;
    }
    public void SetgameDesignHours(int value)
    {
        gameDesignHours = value;
        CategoryHoursAssigned = true;
    }
    public void SetgraphicDesignHours(int value)
    {
        graphicDesignHours = value;
        CategoryHoursAssigned = true;
    }

    public void SetsoundDesignHours(int value)
    {
        soundDesignHours = value;
        CategoryHoursAssigned = true;
    }

    public bool AreCategoryHoursAssigned()
    {
        return CategoryHoursAssigned;
    }

    public void ResetAllHours(){
      workinghours = 32;
      codingHours = 0;
      gameDesignHours = 0;
      graphicDesignHours = 0;
      soundDesignHours = 0;
      CategoryHoursAssigned = false;
    }


    public Sprite GetAvatar(){
      return profile_picture;
    }

    public void setProblemCharacter (bool problemCharacter) {
      this.problemCharacter = problemCharacter;
    }

    public bool getProblemCharacter () {
      return problemCharacter;
    }

    
   
}
