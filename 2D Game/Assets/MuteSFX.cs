using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MuteSFX : MonoBehaviour
{
    public void muteSound(bool mute)
    {
        AudioSource[] sounds;
        sounds = GetComponents<AudioSource>();
        if (mute)
            foreach (AudioSource s in sounds)
            {
                s.mute = false;
                AudioManager.muted = false;
            }
                else
                {
                    foreach (AudioSource s in sounds)
                    {
                        s.mute = true;
                        AudioManager.muted = true;
                    }
                }

    }

    private void Awake()
    {
        AudioSource[] sounds;
        sounds = GetComponents<AudioSource>();
        foreach (AudioSource s in sounds)
        {
            s.mute = AudioManager.muted;
        }
    }
}
