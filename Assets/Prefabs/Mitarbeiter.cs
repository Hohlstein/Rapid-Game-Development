using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mitarbeiter : MonoBehaviour
{

      [SerializeField]
    private string firstName;
      [SerializeField]
    private string lastName;
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


    public int getStressed(int stress){
        this.stresslevel += stress;
        return this.stresslevel;
    }

   
}
