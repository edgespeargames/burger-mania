using System;
using System.Collections;
using UnityEngine;

//Taken from Brackeys Audio in Unity introduction
//https://www.youtube.com/watch?v=6OT43pvUyfY

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //Array of sounds

    public bool mute; //Toggle mute

    public static AudioManager instance; //Singleton

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //Assign an audio source component to each audio clip and set the clip, volume, pitch, loop and mute settings
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    //Start muted or unmuted depending on the last state the mute variable was saved
    private void Start()
    {
        SaveSystem.LoadMute();
        GetComponentInChildren<ToggleMuteImage>().OnToggleMute(mute);
        SetMute();
    }

    //Return whether the sound passed as an argument is currently playing
    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return false;

        return s.source.isPlaying;
    }

    //Fade all sounds down to volume 0
    public void FadeAll()
    {
        foreach (Sound s in sounds)
        {
            StartCoroutine(Fade(s.source));
        }
    }

    //Mute all sounds if mute variable is true, otherwise unmute
    public void SetMute()
    {
        foreach (Sound s in sounds)
        {
            if (mute)
            {
                s.source.volume = 0;
            }
            else
            {
                s.source.volume = 1;
            }
        }
    }

    //Helper method to toggle the mute variable, 
    //mute or unmute all sounds,
    //update the mute UI image,
    //Save the current state of whether muted or note
    public void MuteToggle()
    {
        mute = !mute;
        SetMute();
        GetComponentInChildren<ToggleMuteImage>().OnToggleMute(mute);
        SaveSystem.SaveMute();
    }

    //Play the sound that is passed as an argument
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Play();
    }

    //Play the sound passed as an argument only once
    public void PlayOnce(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.PlayOneShot(s.clip);
    }

    //Stop playing the sound passed as an argument
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Stop();
    }

    //Pause the sound passed as an argument
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Pause();
    }

    //Resume the sound passed as an argument
    public void Resume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.UnPause();
    }

    //Fade out the sound passed as an argument
    public void FadeOut(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        StartCoroutine(Fade(s.source));
    }

    //Coroutine to fade out the audio source passed through the FadeOut method
    IEnumerator Fade(AudioSource source)
    {
        while (source.volume > 0)
        {
            source.volume -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        source.Stop();
        source.volume = 1;
    }
}
