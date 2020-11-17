using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    //public HoverButton hoverButton;
    public DoorController door1;
    public DoorController door2;
    public Text button_text;
    private bool button_pushed = false;
    private AudioSource clicked_clip;
    public GameObject teleport_area;

    private void Start()
    {
        //hoverButton.onButtonDown.AddListener(OnButtonDown);
        clicked_clip = GetComponent<AudioSource>();
    }

    public void startButton()
    {
        clicked_clip.Play();
        if (button_pushed)
        {
            //Reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            teleport_area.SetActive(true);
            door1.open(); //player can now get through
            door2.open();

            button_text.text = "Restart Game";  // Now button is set to a restart button
            button_pushed = true;
        }
    }

    public void endButton()
    {
        clicked_clip.Play();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit ();
        #endif
    }
}