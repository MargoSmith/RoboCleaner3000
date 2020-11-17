using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachment : MonoBehaviour
{
    public Transform receiver1;
    public Transform receiver2;
    public Transform attach1;
    public Transform attach2;
    public Transform targetPosition;
    // Use this for initialization
    public GameObject targetEffect;
    private Rigidbody myRb;
    public float attachDistance = 0.2f;
    public bool pickedUp = false;
    public bool attachedCheck = false;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }
    public void onPickup()
    {
        if (!attachedCheck)
        {
            pickedUp = true;
            targetEffect.SetActive(true);
        }
    }

    //dropping a component checks the distance from its target receivers to see if the player has it in the correct position
    public void onDrop()
    {
        pickedUp = false;
        if (!attachedCheck)
        {
            targetEffect.SetActive(false);
        }

        if (Vector3.Distance(receiver1.position, attach1.position) < attachDistance && Vector3.Distance(receiver2.position, attach2.position) < attachDistance)
        {
            print("attached");
            attachedCheck = true;
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
            myRb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}