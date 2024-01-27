using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public static Jukebox singleton; 

    

    public enum MusicGenrePlaying { Rock, Disco, Jazz }

    [SerializeField] public Jukebox.MusicGenrePlaying _musicGenrePlaying;
    void Start()
    {
        if(singleton != null)
        {
            Destroy(singleton);
        }
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
