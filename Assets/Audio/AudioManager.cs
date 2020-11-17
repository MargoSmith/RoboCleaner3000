using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager



{     public static void PlaySound()
        {
            GameObject sound = new GameObject("Sound");
            AudioSource audio_source = sound.AddComponent<AudioSource>();
        }
}
