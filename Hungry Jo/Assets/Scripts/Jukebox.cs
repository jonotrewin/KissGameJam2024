using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jukebox : MonoBehaviour, IInteract
{
    public static Jukebox singleton;
    AudioManager audioManager;
    [SerializeField] String[] songNames = new string[3];
    public enum MusicGenrePlaying { Rock, Disco, Jazz }

    [SerializeField] public Jukebox.MusicGenrePlaying _musicGenrePlaying;
    void Start()
    {
        if (singleton != null)
        {
            Destroy(singleton);
        }
        singleton = this;

        PlaySong((int)_musicGenrePlaying);
        Debug.Log(Enum.GetValues(typeof(MusicGenrePlaying)).Length);
    }

    void IInteract.Interact(UnityEngine.GameObject player)
    {
        AudioManager.instance.Stop(songNames[(int)_musicGenrePlaying]);
        if ((int)_musicGenrePlaying == Enum.GetValues(typeof(MusicGenrePlaying)).Length-1)
        {

            _musicGenrePlaying = Jukebox.MusicGenrePlaying.Rock;
        }
        else
        {          
            _musicGenrePlaying++;
        }
        PlaySong((int)_musicGenrePlaying);

    }

    private void PlaySong(int songNumber)
    {
        AudioManager.instance.Play(songNames[songNumber]);
    }

}
