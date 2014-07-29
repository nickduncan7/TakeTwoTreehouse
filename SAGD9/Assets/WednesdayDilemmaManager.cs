using System;
using UnityEngine;
using System.Collections;

public class WednesdayDilemmaManager : MonoBehaviour
{


    private float timer;

    // Use this for initialization
	void Start ()
	{

	    var gdo = GameDataObjectHelper.GetGameData();
        if (gdo.SelectedScript.DilemmaDescription == string.Empty)
            Application.LoadLevel("DailyChoice");

        if (gdo.SelectedScript.Dilemma == null)
            gdo.SelectedScript.Dilemma = new Action(() => { });

        gdo.SelectedScript.Dilemma.Invoke();

	    GameObject.Find("Label").GetComponent<UILabel>().text = gdo.SelectedScript.DilemmaDescription;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer += Time.deltaTime;

	    if (timer >= 7)
	    {
	        FaderHelper.FadeToBlack();
	        if (FaderHelper.BlackTransitionComplete())
	        {
	            Application.LoadLevel("DailyChoice");
	        }
	    }
	}
}
