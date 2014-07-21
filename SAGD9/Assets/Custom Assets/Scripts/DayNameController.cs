using UnityEngine;
using System.Collections;

public class DayNameController : MonoBehaviour
{

    public bool Short = false;
    public bool RedFlasher = false;
	// Use this for initialization
	void Start ()
	{
	    var gameScript = GameDataObjectHelper.GetGameData();
        Debug.Log(gameScript.GetCurrentDay());
	    switch (gameScript.GetCurrentDay())
	    {
            case Days.Sunday:
	            guiText.text = RedFlasher ? "•SUNDAY" : "SUNDAY";
	            if (Short)
	                guiText.text = "SUN";
	            break;
            case Days.Monday:
                guiText.text = RedFlasher ? "•MONDAY" : "MONDAY";
                if (Short)
                    guiText.text = "MON";
                break;
            case Days.Tuesday:
                guiText.text = RedFlasher ? "•TUESDAY" : "TUESDAY";
                if (Short)
                    guiText.text = "TUE";
                break;
            case Days.Wednesday:
                guiText.text = RedFlasher ? "•WEDNESDAY" : "WEDNESDAY";
                if (Short)
                    guiText.text = "WED";
                break;
            case Days.Thursday:
                guiText.text = RedFlasher ? "•THURSDAY" : "THURSDAY";
                if (Short)
                    guiText.text = "THU";
                break;
            case Days.Friday:
                guiText.text = RedFlasher ? "•FRIDAY" : "FRIDAY";
                if (Short)
                    guiText.text = "FRI";
                break;
            case Days.Saturday:
                guiText.text = RedFlasher ? "•SATURDAY" : "SATURDAY";
                if (Short)
                    guiText.text = "SAT";
                break;

	    }
	}

    // Update is called once per frame
	void Update () {
	
	}
}
