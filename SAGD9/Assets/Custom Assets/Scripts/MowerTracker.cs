using System;
using UnityEngine;
using System.Collections;

public class MowerTracker : MonoBehaviour
{

    public int TotalGrass = 0;
    public int GrassTilesMowed = 0;
    private float timer = 0f;
    private bool moneyDispensed = false;
    public AudioClip FinishSound;


    // Use this for initialization
	void Start () {
	
	}

    private IEnumerator Done()
    {
        var fadein = TweenAlpha.Begin(GameObject.Find("DoneContainer"), 0.4f, 1.1f);
        fadein.PlayForward();
        yield return null;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (GrassTilesMowed == TotalGrass)
	    {
	        if (!moneyDispensed)
	        {
	            if (GameDataObjectHelper.GetGameData().IsGrounded)
	            {
                    GameObject.Find("SelectedLabel").GetComponent<UILabel>().text =
                    String.Format("Chores complete!{0}You are no longer [i][ccff55]{1}![-][/i]",
                        System.Environment.NewLine, "grounded");
	                GameDataObjectHelper.GetGameData().UngroundPlayer();
	            }
                else
	            {

	                if (GameDataObjectHelper.GetGameData().CastContains("Your Little Brother"))
	                {
                        GameObject.Find("SelectedLabel").GetComponent<UILabel>().text =
                    String.Format("Chores complete!{0}You earned [i][ccff55]{1}![-][/i]",
                        System.Environment.NewLine, "$15");
	                    GameDataObjectHelper.GetGameData().Money += 15;
	                }
	                else
	                {
                        GameObject.Find("SelectedLabel").GetComponent<UILabel>().text =
                    String.Format("Chores complete!{0}You earned [i][ccff55]{1}![-][/i]",
                        System.Environment.NewLine, "$10");
	                    GameDataObjectHelper.GetGameData().Money += 10;
	                }
	            }
                //audio.PlayOneShot(FinishSound);
	            moneyDispensed = true;
	        }

	        StartCoroutine(Done());

	        timer += Time.deltaTime;
	        if (timer >= 5f)
	        {
                GameObject.Find("fader").GetComponent<TriggeredFader>().FadeToBlack();
	            if (GameObject.Find("fader").GetComponent<TriggeredFader>().BlackTransitionComplete())
	            {
	                GameDataObjectHelper.GetGameData().NextDay();
	                Application.LoadLevel("DayTitleCard");
	            }
	        }
	    }
	}
}
