using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private GameObject backMusic;
    private AudioClip[] shortSounds;

    public float Volume {
        get {
            return backMusic.GetComponent<AudioSource>().volume;
        }
        private set
        {
            backMusic.GetComponent<AudioSource>().volume = value;
        }
    }

    void Start () {
        backMusic = GameObject.Find("Universe Music");
        shortSounds = Resources.LoadAll<AudioClip>("Sounds");
    }

    public void PlayMusic()
    {
        backMusic.GetComponent<AudioSource>().Play();
    }

    public void StopMusic()
    {
        backMusic.GetComponent<AudioSource>().Stop();
    }

    public void PlayRandomSound()
    {
        AudioSource.PlayClipAtPoint(shortSounds[Random.Range(0,shortSounds.Length)], transform.position);
    }

    public void SetVolume(float value)
    {
        Volume = 0.3f;
    }
}
