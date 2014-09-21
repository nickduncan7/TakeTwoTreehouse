using System;
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


    private IEnumerator Done()
    {
        var fadein = TweenAlpha.Begin(GameObject.Find("DoneContainer"), 0.4f, 1.1f);
        fadein.PlayForward();

        yield return new WaitForSeconds(3.5f);

        transitionStarted = true;
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

                if (actionManager.SelectedAction.Name == "Do Chores")
                {
                    gameDataScript.ConsecutiveDaysNotMowed = 0;
                    GameObject.Find("SelectedLabel").GetComponent<UILabel>().text =
                    String.Format("Selected{0}[i][ccff55]{1}![-][/i]",
                        System.Environment.NewLine, "chores");
                }
                else if (actionManager.SelectedAction.Name == "Post Process a Scene")
                {
                    gameDataScript.ConsecutiveDaysNotMowed++;
                    GameObject.Find("SelectedLabel").GetComponent<UILabel>().text =
                    String.Format("Selected{0}[i][ccff55]{1}![-][/i]",
                        System.Environment.NewLine, "post processing");
                }
                else
                {
                    gameDataScript.ConsecutiveDaysNotMowed++;
                    GameObject.Find("SelectedLabel").GetComponent<UILabel>().text =
                    String.Format("Selected{0}[i][ccff55]{1}![-][/i]",
                        System.Environment.NewLine, "scene recording");
                }

                StartCoroutine(Done());

                activated = true;
            }
        }
    }
}
