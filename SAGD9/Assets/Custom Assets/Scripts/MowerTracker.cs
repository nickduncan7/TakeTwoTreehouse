﻿using UnityEngine;
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
	
	// Update is called once per frame
	void Update ()
	{
	    if (GrassTilesMowed == TotalGrass)
	    {
	        if (!moneyDispensed)
	        {
	            if (GameDataObjectHelper.GetGameData().IsGrounded)
	            {
                    UIManagerHelper.GetUIManager().UpdateTitleText("Completed Chores");
                    UIManagerHelper.GetUIManager().UpdateSubTitleText("Mowing Complete! You are no longer grounded.");
	                GameDataObjectHelper.GetGameData().UngroundPlayer();
	            }
                else
	            {
                    UIManagerHelper.GetUIManager().UpdateTitleText("Completed Chores");

	                if (GameDataObjectHelper.GetGameData().CastContains("Your Little Brother"))
	                {
                        UIManagerHelper.GetUIManager().UpdateSubTitleText("Mowing Complete! You earned $15");
	                    GameDataObjectHelper.GetGameData().Money += 15;
	                }
	                else
	                {
                        UIManagerHelper.GetUIManager().UpdateSubTitleText("Mowing Complete! You earned $10");
	                    GameDataObjectHelper.GetGameData().Money += 10;
	                }
	            }
                audio.PlayOneShot(FinishSound);
	            moneyDispensed = true;
	        }

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
