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
    private Sprite profile_picture;


 
    // Start is called before the first frame update
    void Start()
    
    {        
        this.stresslevel = 0;
        this.workinghours = 0;


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

    public int getStressed(int stress){
        this.stresslevel += stress;
        return this.stresslevel;
    }

    public Sprite GetAvatar(){
      return profile_picture;
    }

    
   
}
