using UnityEngine;
using System.Collections;

public class GrassMowedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameData = GameDataObjectHelper.GetGameData();
	}

    public Sprite SpriteToChangeTo;
    public AudioClip MowSound;

    private GameDataScript gameData;
    private bool isMowed = false;

	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isMowed && gameData != null)
        {
            GetComponent<SpriteRenderer>().sprite = SpriteToChangeTo;
            isMowed = true;
            GetComponent<AudioSource>().PlayOneShot(MowSound, 0.7f);
            MowerTrackerHelper.GetMowerDataScript().GrassTilesMowed++;
        }
    }

}
