using UnityEngine;
using System.Collections;

public class MowerTracker : MonoBehaviour
{

    public int TotalGrass = 0;
    public int GrassTilesMowed = 0;
    private float timer = 0f;
    private bool moneyDispensed = false;


    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (GrassTilesMowed == TotalGrass)
	    {
	        if (!moneyDispensed)
	        {
                UIManagerHelper.GetUIManager().UpdateTitleText("Completed Chores");
                UIManagerHelper.GetUIManager().UpdateSubTitleText("Mowing Complete! You earned $10");
	            GameDataObjectHelper.GetGameData().Money += 10;
	            moneyDispensed = true;
	        }

	        timer += Time.deltaTime;
	        if (timer >= 5f)
	        {
                GameObject.Find("Fader").GetComponent<TriggeredFader>().FadeToBlack();
	            if (GameObject.Find("Fader").GetComponent<TriggeredFader>().BlackTransitionComplete())
	            {
	                GameDataObjectHelper.GetGameData().NextDay();
	                Application.LoadLevel("DayTitleCard");
	            }
	        }
	    }
	}
}
