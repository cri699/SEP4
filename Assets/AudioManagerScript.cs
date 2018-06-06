using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManagerScript : MonoBehaviour {

    private AudioSource menuMusic, cardPlace, cardDraw, endGame;
    public static AudioManagerScript instance;
    public AudioClip cardPlaceAudio, cardDrawAudio, menuMusicAudio, endGameAudio;



    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;

    }

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
    }

    void Start()
    {
        cardPlace = AddAudio(cardPlaceAudio, false, false, 0.5f);
        cardDraw = AddAudio(cardDrawAudio, false, false, 0.5f);
        menuMusic = AddAudio(menuMusicAudio, true, false, 0.4f);
        endGame = AddAudio(endGameAudio, false, false, 0.5f);

        menuMusic.Play();
    }


    public void playCardDraw()
    {
        cardDraw.Play();
    }

    public void playCardPlace()
    {
        cardPlace.Play();
    }

    public void playEndGame()
    {
        endGame.Play();
    }
}
