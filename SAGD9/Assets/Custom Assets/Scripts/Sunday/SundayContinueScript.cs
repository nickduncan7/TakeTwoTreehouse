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
