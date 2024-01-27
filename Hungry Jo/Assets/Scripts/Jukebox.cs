using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour, IInteract
{
    public static Jukebox singleton;



    public enum MusicGenrePlaying { Rock, Disco, Jazz }

    [SerializeField] public Jukebox.MusicGenrePlaying _musicGenrePlaying;
    void Start()
    {
        if (singleton != null)
        {
            Destroy(singleton);
        }
        singleton = this;

        Debug.Log(Enum.GetValues(typeof(MusicGenrePlaying)).Length);
    }

    void IInteract.Interact(UnityEngine.GameObject player)
    {

        if ((int)_musicGenrePlaying == Enum.GetValues(typeof(MusicGenrePlaying)).Length - 1)
        {
            _musicGenrePlaying = 0;
        }
        else _musicGenrePlaying++;

    }
}
