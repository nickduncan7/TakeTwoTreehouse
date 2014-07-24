using UnityEngine;
using System.Collections;

public class DayTickerController : MonoBehaviour
{
    private GameDataScript script;
	// Use this for initialization
	void Start ()
	{
       
        script = GameDataObjectHelper.GetGameData();
        var DayArrow = GameObject.Find("CurrentDayArrow");

	    var Sunday = GameObject.Find("Sunday");
        var Monday = GameObject.Find("Monday");
        var Tuesday = GameObject.Find("Tuesday");
        var Wednesday = GameObject.Find("Wednesday");
        var Thursday = GameObject.Find("Thursday");
        var Friday = GameObject.Find("Friday");
	    var Saturday = GameObject.Find("Saturday");

        switch (script.DayOfWeek)
        {
            case Days.Sunday:
                Sunday.GetComponent<UIWidget>().alpha = 1f;
                DayArrow.GetComponent<UI2DSprite>().SetAnchor(Sunday);
                DayArrow.GetComponent<UI2DSprite>().UpdateAnchors();
                break;
            case Days.Monday:
                Monday.GetComponent<UIWidget>().alpha = 1f;
                DayArrow.GetComponent<UI2DSprite>().SetAnchor(Monday);
                DayArrow.GetComponent<UI2DSprite>().UpdateAnchors();
                break;
            case Days.Tuesday:
                Tuesday.GetComponent<UIWidget>().alpha = 1f;
                DayArrow.GetComponent<UI2DSprite>().SetAnchor(Tuesday);
                DayArrow.GetComponent<UI2DSprite>().UpdateAnchors();
                break;
            case Days.Wednesday:
                Wednesday.GetComponent<UIWidget>().alpha = 1f;
                DayArrow.GetComponent<UI2DSprite>().SetAnchor(Wednesday);
                DayArrow.GetComponent<UI2DSprite>().UpdateAnchors();
                break;
            case Days.Thursday:
                Thursday.GetComponent<UIWidget>().alpha = 1f;
                DayArrow.GetComponent<UI2DSprite>().SetAnchor(Thursday);
                DayArrow.GetComponent<UI2DSprite>().UpdateAnchors();
                break;
            case Days.Friday:
                Friday.GetComponent<UIWidget>().alpha = 1f;
                DayArrow.GetComponent<UI2DSprite>().SetAnchor(Friday);
                DayArrow.GetComponent<UI2DSprite>().UpdateAnchors();
                break;
            case Days.Saturday:
                Saturday.GetComponent<UIWidget>().alpha = 1f;
                DayArrow.GetComponent<UI2DSprite>().SetAnchor(Saturday);
                DayArrow.GetComponent<UI2DSprite>().UpdateAnchors();
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
