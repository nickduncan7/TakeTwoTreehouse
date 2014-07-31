using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	// Use this for initialization

    public AudioClip Song1;
    public AudioClip Song2;

    private AudioClip NextSong;
    

	void Start ()
	{
	    NextSong = Song1;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!audio.isPlaying)
	    {
	        if (NextSong == Song1)
	        {
	            audio.clip = Song1;
                audio.PlayDelayed(1);
	            NextSong = Song2;
	        }
	        else
	        {
                audio.clip = Song2;
                audio.PlayDelayed(1);
                NextSong = Song1;
	        }
	    }
            
	}
}
