using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("+ right, - left")]
    [SerializeField]
    private float ztravelDist = 0;
    private float speed = 2f;

    private Vector3 startPos;
    private Vector3 endPos;
    private int direction;

    private bool game_start = false;

    void Awake()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, 0, ztravelDist);
        Debug.Log(endPos);


        if (ztravelDist > 0) //traveling left or right
            direction = 1;
        else
            direction = -1;
    }


    public void open()
    {
        game_start = true;
    }


    void FixedUpdate()
    {
        //Move smoothing between startPos and endPos

        //Handle horizontal movement
        if (game_start && ztravelDist != 0)
        {
            if (Mathf.Abs(transform.position.x - startPos.x) >= Mathf.Abs(ztravelDist))
            {
                Debug.Log("Doors Open");
            }
            else
            {
                Debug.Log("opening door");
                transform.position += new Vector3(0, 0, direction) * speed * Time.fixedDeltaTime;
            }
                
        }

    }
}
