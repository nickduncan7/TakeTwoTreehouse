using UnityEngine;
using System.Collections;

public class StealMusicPlayer : MonoBehaviour
{

    private GameObject musicPlayer;
	// Use this for initialization
	void Start ()
	{
	    musicPlayer = GameObject.Find("MusicPlayer");
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (musicPlayer)
	        musicPlayer.transform.position = this.transform.position;
	}
}
