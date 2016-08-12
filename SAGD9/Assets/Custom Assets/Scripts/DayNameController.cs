using UnityEngine;
using System.Collections;

public class DayNameController : MonoBehaviour
{

    public bool Short = false;
    public bool RedFlasher = false;
	// Use this for initialization
	void Start ()
	{
	    var UILabel = this.GetComponent<UILabel>();
	    var gameScript = GameDataObjectHelper.GetGameData();
	    if (GetComponent<GUIText>())
            switch (gameScript.GetCurrentDay())
            {
                case Days.Sunday:
                    GetComponent<GUIText>().text = RedFlasher ? "•SUNDAY" : "SUNDAY";
                    if (Short)
                        GetComponent<GUIText>().text = "SUN";
                    break;
                case Days.Monday:
                    GetComponent<GUIText>().text = RedFlasher ? "•MONDAY" : "MONDAY";
                    if (Short)
                        GetComponent<GUIText>().text = "MON";
                    break;
                case Days.Tuesday:
                    GetComponent<GUIText>().text = RedFlasher ? "•TUESDAY" : "TUESDAY";
                    if (Short)
                        GetComponent<GUIText>().text = "TUE";
                    break;
                case Days.Wednesday:
                    GetComponent<GUIText>().text = RedFlasher ? "•WEDNESDAY" : "WEDNESDAY";
                    if (Short)
                        GetComponent<GUIText>().text = "WED";
                    break;
                case Days.Thursday:
                    GetComponent<GUIText>().text = RedFlasher ? "•THURSDAY" : "THURSDAY";
                    if (Short)
                        GetComponent<GUIText>().text = "THU";
                    break;
                case Days.Friday:
                    GetComponent<GUIText>().text = RedFlasher ? "•FRIDAY" : "FRIDAY";
                    if (Short)
                        GetComponent<GUIText>().text = "FRI";
                    break;
                case Days.Saturday:
                    GetComponent<GUIText>().text = RedFlasher ? "•SATURDAY" : "SATURDAY";
                    if (Short)
                        GetComponent<GUIText>().text = "SAT";
                    break;

            }
        else
	        switch (gameScript.GetCurrentDay())
	        {
                case Days.Sunday:
                    UILabel.text = RedFlasher ? "•SUNDAY" : "SUNDAY";
	                if (Short)
                        UILabel.text = "SUN";
	                break;
                case Days.Monday:
                    UILabel.text = RedFlasher ? "•MONDAY" : "MONDAY";
                    if (Short)
                        UILabel.text = "MON";
                    break;
                case Days.Tuesday:
                    UILabel.text = RedFlasher ? "•TUESDAY" : "TUESDAY";
                    if (Short)
                        UILabel.text = "TUE";
                    break;
                case Days.Wednesday:
                    UILabel.text = RedFlasher ? "•WEDNESDAY" : "WEDNESDAY";
                    if (Short)
                        UILabel.text = "WED";
                    break;
                case Days.Thursday:
                    UILabel.text = RedFlasher ? "•THURSDAY" : "THURSDAY";
                    if (Short)
                        UILabel.text = "THU";
                    break;
                case Days.Friday:
                    UILabel.text = RedFlasher ? "•FRIDAY" : "FRIDAY";
                    if (Short)
                        UILabel.text = "FRI";
                    break;
                case Days.Saturday:
                    UILabel.text = RedFlasher ? "•SATURDAY" : "SATURDAY";
                    if (Short)
                        UILabel.text = "SAT";
                    break;

	        }
	}

    // Update is called once per frame
	void Update () {
	
	}
}
