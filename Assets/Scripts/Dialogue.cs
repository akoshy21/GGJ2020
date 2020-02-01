using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private bool nameRandGo;
    private bool deathRandGo;
    private bool bsRandGo;
    
    public Text testline;
    public List<string> names = new List<string>();
    public List<string> backstory = new List<string>();
    public List<string> death = new List<string>();


    public int bsrand;
    // Start is called before the first frame update
    void Start()

    {
        /*names.Add("Joe");
        names.Add("Stan");
        names.Add("James");
        names.Add("Bingus");*/
        names.AddRange(new string[] {"Jimbo", "Sam"});
        death.AddRange(new string[] {"murder", "death"});
    }

    string newBackstory()
    {
        int bsCount = Random.Range(0, 5);

        switch (bsCount)
        {
            case 0:
                backstory.Add(randomizeName() + " died from " + randomizeDeath());
                return backstory[backstory.Count-1];
            case 1:
                backstory.Add(randomizeName() + " was killed by " + randomizeDeath());
                return backstory[backstory.Count-1];
            case 2:
                backstory.Add(randomizeName() + " dead b3cuz " + randomizeDeath());
                return backstory[backstory.Count-1];
            case 3:
                backstory.Add("I want to fuck " + randomizeName() + " but they died because " + randomizeDeath());
                return backstory[backstory.Count-1];
            case 4:
                backstory.Add("HOLY SHIT! " + randomizeName() + " was stabbed but actually died from   " + randomizeDeath());
                return backstory[backstory.Count-1];
            default:
                return "";
                    
        } 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(newBackstory());
        }
        
        //testline.text = names[Random.Range(0, names.Count)] + " is having a baby";
       
    }
    public string randomizeName()
    {
        string name = names[Random.Range(0,names.Count)];
        return name;


        /*  if (Input.GetKeyDown(KeyCode.A))
          {
              Debug.Log(names[namerand]);  
              
              
          }*/
    }

    public string randomizeDeath()
    {
        string die =  death[Random.Range(0, death.Count)];
        return die;
    }
    public string GetBackStory()
    {
        int rand = Random.Range(0, backstory.Count);
        string bs = backstory[rand];
        //usedBackstory.Add(bs);
        backstory.RemoveAt(rand);
        return bs;
    }
}


