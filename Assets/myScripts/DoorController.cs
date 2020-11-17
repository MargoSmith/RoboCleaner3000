using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("+ right, - left")]
    [SerializeField]
    private float ztravelDist = 0;
    [SerializeField]
    private float speed = 1f;

    private Vector3 startPos;
    private Vector3 endPos;
    private int direction;

    public AudioSource sound;

    private bool game_start = false;

    void Awake()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, 0, ztravelDist);


        if (ztravelDist > 0) //traveling left or right
            direction = 1;
        else
            direction = -1;

    }


    public void open()
    {
        if (sound)
        {
            sound.Play();
        }

        game_start = true;
    }


    void FixedUpdate()
    {

        //Handle horizontal movement
        if (game_start && ztravelDist != 0)
        {
            if (Mathf.Abs(transform.position.x - startPos.x) >= Mathf.Abs(ztravelDist))
            {
                //Destroy script
                Destroy(this);
            }
            else
            {
                transform.position += new Vector3(0, 0, direction) * speed * Time.fixedDeltaTime;
            }
                
        }

    }
}
