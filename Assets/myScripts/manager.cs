using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] robotComponents;
    public GameObject fullRobot;

    public int score = 0;
    public int scoreLimit = 5;

    bool gameEnded = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= scoreLimit && !gameEnded)
        {
            print("game Finnished");
            gameEnded = true;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            destroyParts();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            checkCompletion();
        }

    }
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
            destroyParts();
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
    //restart the game
    public void restartScene()
    {

    }

    public void increaseScore()
    {
        score++;
    }
}
