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
	    if (!GetComponent<AudioSource>().isPlaying)
	    {
	        if (NextSong == Song1)
	        {
	            GetComponent<AudioSource>().clip = Song1;
                GetComponent<AudioSource>().PlayDelayed(1);
	            NextSong = Song2;
	        }
	        else
	        {
                GetComponent<AudioSource>().clip = Song2;
                GetComponent<AudioSource>().PlayDelayed(1);
                NextSong = Song1;
	        }
	    }
            
	}
}
