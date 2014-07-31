using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class DailyChoiceButton : MonoBehaviour
{

    private GameDataScript gameDataScript;
    private ActionManager actionManager;

	// Use this for initialization
	void Start ()
	{
	    actionManager = GameObject.Find("ActionManager").GetComponent<ActionManager>();
	    gameDataScript = GameDataObjectHelper.GetGameData();
	}


    // Update is called once per frame
    void Update()
    {
        if (transitionStarted)
        {
            timer += Time.deltaTime;
            if (timer >= 0.8)
            {
                FaderHelper.FadeToBlack();
            }
            if (timer >= 4 && FaderHelper.BlackTransitionComplete())
            {
                Application.LoadLevel(actionManager.SelectedAction.LevelToLoad);
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
                if (actionManager.SelectedAction.Name != "Do Chores")
                    gameDataScript.ConsecutiveDaysNotMowed++;
                else
                {
                    gameDataScript.ConsecutiveDaysNotMowed = 0;
                }
                transitionStarted = true;
                activated = true;
            }
        }
    }
}
