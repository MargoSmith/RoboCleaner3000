using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAudio : MonoBehaviour
{

    private AudioSource clip;

    private void Start()
    {
        clip = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "room")
        {
            clip.Play();
        }
    }
}
