using UnityEngine;
using System.Collections;

public class SundayContinueScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (transitionStarted)
	    {
	        timer += Time.deltaTime;
	        if (timer >= 3)
	        {
                FaderHelper.FadeToBlack();
	        }
            if (timer >= 7 && FaderHelper.BlackTransitionComplete())
            {
                GameDataObjectHelper.GetGameData().NextDay();
                Application.LoadLevel("ChooseKids");
            }
	    }
	}


    private float timer;
    private bool transitionStarted = false;
    private bool activated = false;

    void OnPress(bool pressed)
    {
        if (pressed)
        {
            if (!activated)
            {
                UIManagerHelper.GetUIManager().UpdateTitleText("Script Selected!");
                var gameDataObject = GameDataObjectHelper.GetGameData();
                gameDataObject.SelectedScript =
                    GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().CurrentlySelectedScript;

                gameDataObject.Money -= gameDataObject.SelectedScript.Budget;
                transitionStarted = true;
                activated = true;
            }
        }
    }
}
