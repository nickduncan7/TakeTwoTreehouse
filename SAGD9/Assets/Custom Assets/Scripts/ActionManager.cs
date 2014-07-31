using System;
using System.ComponentModel;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

    public Sprite Arthur;
    public Sprite Tomika;
    public Sprite Jacques;
    public Sprite Paula;
    public Sprite Chris;
    public Sprite Richy;
    public Sprite Ali;
    public Sprite Jill;
    public Sprite Kevin;
    public Sprite Ralph;
    public Sprite Daniel;
    public Sprite May;
    public Sprite Brother;

	// Use this for initialization
	void Start () {
        var gameDataObject = GameDataObjectHelper.GetGameData();

	    GameObject.Find("SubTitleLabel").GetComponent<UILabel>().text = "-" + gameDataObject.SelectedScript.Name + "-";

        GameObject.Find("Cast1").GetComponent<UI2DSprite>().sprite2D = GetSpriteForKid(gameDataObject.Cast[0]);
        GameObject.Find("Cast1").transform.FindChild("Label").GetComponent<UILabel>().text = gameDataObject.Cast[0].Name;
        GameObject.Find("Cast1").transform.FindChild("Availability").GetComponent<UILabel>().text = gameDataObject.Cast[0].GetAvailabilityShort();


        if (!gameDataObject.Cast[0].Availability.Contains(gameDataObject.GetCurrentDay()))
        {
            GameObject.Find("Cast1").GetComponent<UI2DSprite>().alpha = 0.4f;
        }

        GameObject.Find("Cast2").GetComponent<UI2DSprite>().sprite2D = GetSpriteForKid(gameDataObject.Cast[1]);
        GameObject.Find("Cast2").transform.FindChild("Label").GetComponent<UILabel>().text = gameDataObject.Cast[1].Name;
        GameObject.Find("Cast2").transform.FindChild("Availability").GetComponent<UILabel>().text = gameDataObject.Cast[1].GetAvailabilityShort();


        if (!gameDataObject.Cast[1].Availability.Contains(gameDataObject.GetCurrentDay()))
        {
            GameObject.Find("Cast2").GetComponent<UI2DSprite>().alpha = 0.4f;
        }

        GameObject.Find("Cast3").GetComponent<UI2DSprite>().sprite2D = GetSpriteForKid(gameDataObject.Cast[2]);
        GameObject.Find("Cast3").transform.FindChild("Label").GetComponent<UILabel>().text = gameDataObject.Cast[2].Name;
        GameObject.Find("Cast3").transform.FindChild("Availability").GetComponent<UILabel>().text = gameDataObject.Cast[2].GetAvailabilityShort();


        if (!gameDataObject.Cast[2].Availability.Contains(gameDataObject.GetCurrentDay()))
        {
            GameObject.Find("Cast3").GetComponent<UI2DSprite>().alpha = 0.4f;
        }

        var SceneButton = GameObject.Find("Shoot Scene Button").GetComponent<ActionsButton>();
        var MowButton = GameObject.Find("Mow Lawn Button").GetComponent<ActionsButton>();
        var PostProcessButton = GameObject.Find("Post Process Button").GetComponent<ActionsButton>();
        var ShootRetakeButton = GameObject.Find("Shoot Retake Button").GetComponent<ActionsButton>();

        SceneButton.AssociatedAction = new GameAction
	    {
	        Name = "Shoot a Scene",
	        Description = "Shoots a scene for your movie. Cast members that are available are highlighted.",
            LevelToLoad = "ShootSceneMinigame",
            Allowed = true
	    };
        MowButton.AssociatedAction = new GameAction
        {
            Name = "Do Chores",
            Description = "Mow the lawn to earn you money, and please your parents. If you don't do this regularly, you might get grounded!",
            LevelToLoad = "MowLawn",
            Allowed = true
        };
        PostProcessButton.AssociatedAction = new GameAction
        {
            Name = "Post Process a Scene",
            Description = "Do some editing to your existing scenes in order to improve the movies' Effects or Action score."
        };
        ShootRetakeButton.AssociatedAction = new GameAction
        {
            Name = "Shoot a Retake",
            Description = "Do a Retake on a scene to max out the scene's benefits towards the movie."
        };

	    if (gameDataObject.IsGrounded)
	    {
            DisallowOutsideTasks("You're grounded!");
	    }

	    else
	    {
	        AllowOutsideTasks();
	    }

        if (!gameDataObject.Cast[0].Availability.Contains(gameDataObject.GetCurrentDay())
            && !gameDataObject.Cast[1].Availability.Contains(gameDataObject.GetCurrentDay())
            && !gameDataObject.Cast[2].Availability.Contains(gameDataObject.GetCurrentDay()))
            SceneButton.Disable();

	    if (SceneButton.IsEnabled)
	    {
            SceneButton.SelectMe();
            return;
	    }

        if(MowButton.IsEnabled)
        {
            MowButton.SelectMe();
            return;
        }


        if (PostProcessButton.IsEnabled)
        {
            PostProcessButton.SelectMe();
            return;
        }

	    if (ShootRetakeButton.IsEnabled)
	    {
	        ShootRetakeButton.SelectMe();
	        return;
	    }
	}

    public Sprite GetSpriteForKid(Kid kid)
    {
        switch (kid.Name)
        {
            case "Arthur":
                return Arthur;
            case "Tomika":
                return Tomika;
            case "Jacques":
                return Jacques;
            case "Paula":
                return Paula;
            case "Chris":
                return Chris;
            case "Richy":
                return Richy;
            case "Ali":
                return Ali;
            case "Jill":
                return Jill;
            case "Kevin":
                return Kevin;
            case "Ralph":
                return Ralph;
            case "Daniel":
                return Daniel;
            case "May":
                return May;
            case "Your Little Brother":
                return Brother;
        }
        return null;
    }

    public void DisallowOutsideTasks(string reason)
    {
        var SceneButton = GameObject.Find("Shoot Scene Button").GetComponent<ActionsButton>();
        var ShootRetakeButton = GameObject.Find("Shoot Retake Button").GetComponent<ActionsButton>();

        SceneButton.Disable();
        SceneButton.AssociatedAction.Allowed = false;

        ShootRetakeButton.Disable();
        ShootRetakeButton.AssociatedAction.Allowed = false;

        actionDisabledReason = reason;
    }

    public void AllowOutsideTasks()
    {
        var SceneButton = GameObject.Find("Shoot Scene Button").GetComponent<ActionsButton>();

        SceneButton.Enable();
        SceneButton.AssociatedAction.Allowed = true;

        //ShootRetakeButton.Enable();
        //ShootRetakeButton.AssociatedAction.Allowed = true;

        actionDisabledReason = String.Empty;
    }

    public GameAction SelectedAction;

    public string actionDisabledReason;

	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateTextLabels(GameAction associatedAction)
    {
        if (associatedAction.Name == "Shoot a Scene")
        {
            GameObject.Find("CastContainer").GetComponent<UIWidget>().alpha = 1f;
        }
        else
        {
            GameObject.Find("CastContainer").GetComponent<UIWidget>().alpha = 0f;
        }

        GameObject.Find("Action Name").GetComponent<UILabel>().text = associatedAction.Name;
        if (associatedAction.Allowed)
            GameObject.Find("Action Description").GetComponent<UILabel>().text = associatedAction.Description;
        else
            GameObject.Find("Action Description").GetComponent<UILabel>().text = associatedAction.Description
                + System.Environment.NewLine + System.Environment.NewLine + 
                "You are currently [i]not allowed[/i] to do this action!";

        if (!String.IsNullOrEmpty(actionDisabledReason))
            GameObject.Find("Action Description").GetComponent<UILabel>().text += (" " + actionDisabledReason);
    }
}
