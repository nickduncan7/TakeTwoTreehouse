using UnityEngine;
using System.Collections;

public class GrassMowedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameData = GameDataObjectHelper.GetGameData();
	}

    public Sprite SpriteToChangeTo;

    private GameDataScript gameData;
    private bool isMowed = false;

	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isMowed && gameData != null)
        {
            gameData.Money += 0.1f;
            GetComponent<SpriteRenderer>().sprite = SpriteToChangeTo;
            isMowed = true;
        }
    }

}
