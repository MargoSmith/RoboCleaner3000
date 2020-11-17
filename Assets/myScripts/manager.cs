using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] robotComponents;
    public GameObject fullRobot;

    public int score = 0;
    private int scoreLimit = 17;

    bool gameEnded = false;
    public GameObject win_canvas;
    public GameObject action_indicator;


    void Start()
    {
        
    }

    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) //for testing/cheating
        {
            destroyParts();
        }
        if (Input.GetKeyDown(KeyCode.R))//for testing/cheating
        {
            checkCompletion();
        }
    

    }
    */


//check robot is fully assembled before activating
public void checkCompletion()
    {
        bool completeCheck = true;
        foreach (GameObject component in robotComponents)
        {
            if (component.name != "torso")
            {
                if (component.GetComponent<attachment>().attachedCheck == false)
                {
                    completeCheck = false;
                }
            }
        }
        if (completeCheck)
        {
            //player success sound
            AudioManager.instance.PlaySound("success");
            action_indicator.SetActive(false);
            destroyParts();
        }
        else
        {
            //play error sound for incomplete
            AudioManager.instance.PlaySound("error");

        }
    }

    //remove components from the game and activate the playable robot
    public void destroyParts()
    {
        foreach (GameObject component in robotComponents){
            component.SetActive(false);
        }
        fullRobot.SetActive(true);
    }


    public void increaseScore()
    {
        score++;

        if (score >= scoreLimit && !gameEnded)
        {
            print("game Finnished");
            gameEnded = true;
            win_canvas.SetActive(true);
        }
    }
}
