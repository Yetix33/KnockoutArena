using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
   
    // On awake, add all audio sources from list
    void Awake()
    {
        // Check if AudioManager already exists
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
        // Dont Destroy on Load so that audio persists between scenes
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            // Create audio source on each sound from array and assign its values
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() 
    {
        Play("Theme");
    }

    // Play sound of given name 
    public void Play(string name)
    {
        // Find sound in sounds array that matches name and play it
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // Check if sound name was found
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found");
        }
        s.source.Play();
    }
}
