using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using Valve.VR;

public class robotControls : MonoBehaviour
{
    public SteamVR_Input_Sources handtype; //lefthand conrols the robot
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    public Transform playerTransform;
    public Transform holdPostiion;
    public GameObject heldObj;

    public SteamVR_Action_Vector2 steering;
    private Animator myAnim;
    public Rigidbody myRb;

    public float throwForce = 100;
    public float speed;
    public float pickupRange = 0.8f;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }
    void Update()
    {
        movement();
        pickup();
    }

    //input detection for robot pickup and let go
    void pickup()
    {      

        if (grabAction.GetState(handtype))
        {
            myAnim.SetBool("holding", true);
            if (grabAction.GetStateDown(handtype)){
                grabNearbyObj();
            }
           
        }
        else if (!grabAction.GetState(handtype))
        {
            myAnim.SetBool("holding", false);
            if (grabAction.GetStateUp(handtype)){
                letGo();
            }
        }
        return ;
    }

    //grab nearby object by detecting all objects in a sphere raycast
    //pickup the first pickupable object in range
    void grabNearbyObj()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, pickupRange, transform.forward, 2.1f);
 
        bool foundObj = false;
        foreach (RaycastHit q in hits)
        {
           if((q.collider.tag =="component" || q.collider.tag == "pickup") && foundObj == false)
            {
                q.collider.GetComponent<Rigidbody>().isKinematic = true;
                q.collider.transform.parent = holdPostiion.transform;
                
                q.collider.transform.localPosition = new Vector3(0,0,0);
                heldObj = q.collider.gameObject;
                foundObj = true;
            }
        }
        
    }

    //reset the held object so that it is unparented
    void letGo()
    {
        if(heldObj != null)
        {
            
            heldObj.transform.parent = null;
            heldObj.GetComponent<Rigidbody>().isKinematic = false;
            heldObj.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
            heldObj = null;
        }
    }
    //joystick/dpad movement controls
    void movement()
    {

        if(steering.GetAxis(handtype) != (new Vector2(0, 0)))
        {
            myAnim.SetBool("running", true);
           
            Vector3 direction = new Vector3(steering.GetAxis(handtype).x, 0, steering.GetAxis(handtype).y);
            Vector3 rightMovement = playerTransform.right * speed * Time.deltaTime * (steering.GetAxis(handtype).x);
            Vector3 upMovement = playerTransform.forward * speed * Time.deltaTime * (steering.GetAxis(handtype).y);

            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            Vector3 tempForward = new Vector3(heading.x, 0, heading.z);
            transform.forward = tempForward;
            transform.position += rightMovement;
            transform.position += upMovement;
        }
        else
        {
            myAnim.SetBool("running", false);
        }
    }
}
