using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binBox : MonoBehaviour
{
    // Start is called before the first frame update

    private manager sceneManager;
    void Start()
    {
        sceneManager = GameObject.Find("manager").GetComponent<manager>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "pickup")
        {
            col.gameObject.SetActive(false);
            sceneManager.increaseScore();
        }
        
    }
}
