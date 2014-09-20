using System;
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
	        if (timer >= 0.1f)
	        {
                FaderHelper.FadeToBlack();
	        }
            if (timer >= 2.1f && FaderHelper.BlackTransitionComplete())
            {
                GameDataObjectHelper.GetGameData().NextDay();
                Application.LoadLevel("ChooseKids");
            }
	    }
	}


    public bool Enabled;

    public void Enable()
    {
        Enabled = true;
        GetComponent<UI2DSprite>().sprite2D = EnabledSprite;
    }

    public void Disable()
    {
        Enabled = false;
        GetComponent<UI2DSprite>().sprite2D = DisabledSprite;
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
    public Sprite EnabledSprite;
    public Sprite DisabledSprite;

    void OnPress(bool pressed)
    {
        if (pressed && Enabled)
        {
            if (!activated)
            {
                var gameDataObject = GameDataObjectHelper.GetGameData();
                gameDataObject.SelectedScript =
                    GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().CurrentlySelectedScript;

                GameObject.Find("SelectedLabel").GetComponent<UILabel>().text =
                    String.Format("Selected{0}[i][ccff55]{1}![-][/i]",
                        System.Environment.NewLine, gameDataObject.SelectedScript.Name);

                gameDataObject.Money -= gameDataObject.SelectedScript.Budget;
                activated = true;
                StartCoroutine(Done());
                
            }
        }
    }

}
