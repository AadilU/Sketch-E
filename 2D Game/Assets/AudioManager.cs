using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundclips;
    // Start is called before the first frame update

    public static AudioManager instance;

    public static bool muted = false;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in soundclips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioc;

            s.source.volume = s.Volume;
            s.source.pitch = s.pitch;

            if (s.name.Equals("Song"))
                s.source.loop = true;
        }
    }

    void Start()
    {
        Play("Song");
    }

    public void Play(string soundName)
    {
        Sound s1 = Array.Find(soundclips, sound => sound.name == soundName);
        if (s1 == null)
            print("Sound not found");
        s1.source.Play();
    }

    public void updateVol(float vol)
    {
        AudioSource[] s4 = GetComponents<AudioSource>();
        
        foreach(AudioSource s in s4)
        {
            if (s.clip.name.Equals("2DGameSong"))
                s.volume = vol;
        }

    }

    public float getVol()
    {
        AudioSource[] s4 = GetComponents<AudioSource>();
        foreach (AudioSource s in s4)
        {
            if (s.clip.name.Equals("2DGameSong"))
                return s.volume;
        }
        return 0;
    }
}
