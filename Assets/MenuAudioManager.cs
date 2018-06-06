using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour {

    public static MenuAudioManager instance;
    //public Sound menuMusic, fire;
    private AudioSource menuMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        menuMusic = GetComponent<AudioSource>();
        menuMusic.Play();
    }

    /*
    public void playMenuMusic(AudioSource source)
    {
        source.PlayOneShot(menuMusic.clip, menuMusic.pitch);
    }

    public void playFireSound(AudioSource source)
    {
        source.PlayOneShot(fire.clip, fire.pitch);
    }*/
}
