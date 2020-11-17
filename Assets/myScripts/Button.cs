using UnityEngine;
using System.Collections;


public class Button : MonoBehaviour
{
    //public HoverButton hoverButton;
    public DoorController door;

    private void Start()
    {
        //hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    public void openDoor()
    {
        door.open();
    }

    public void endGame()
    {
        //Debug.Log("quiting");
    }
}