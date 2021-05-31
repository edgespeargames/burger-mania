using UnityEngine.Audio;
using UnityEngine;

//Taken from Brackeys Audio in Unity introduction
//https://www.youtube.com/watch?v=6OT43pvUyfY

[System.Serializable]
public class Sound
{
    public string name; //name of the sound
    public AudioClip clip; //audioclip of the sound

    [Range(0f, 1f)]
    public float volume; //volume slider, min 0 max 1
    [Range(.1f, 3f)]
    public float pitch; //pitch slider, min .1 max 3

    public bool loop; //loop - true or false

    public bool mute; //mute - true or false

    [HideInInspector]
    public AudioSource source; //Audiosource
}
