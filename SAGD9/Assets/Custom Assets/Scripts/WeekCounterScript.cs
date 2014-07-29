using UnityEngine;
using System.Collections;

public class WeekCounterScript : MonoBehaviour {
    private GameDataScript gameDataObject;

    // Use this for initialization
	void Start ()
	{
	    gameDataObject = GameDataObjectHelper.GetGameData();
        if (gameDataObject.Week != 5)
	        guiText.text = string.Format("Week {0}", gameDataObject.Week);
        else
        {
            guiText.text = "Last Week";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
