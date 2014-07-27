using System;
using System.ComponentModel;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var SelectionArrow = GameObject.Find("SelectionArrow");

        var SceneButton = GameObject.Find("Shoot Scene Button").GetComponent<ActionsButton>();
        var MowButton = GameObject.Find("Mow Lawn Button").GetComponent<ActionsButton>();
        var PostProcessButton = GameObject.Find("Post Process Button").GetComponent<ActionsButton>();
        var ShootRetakeButton = GameObject.Find("Shoot Retake Button").GetComponent<ActionsButton>();

        SceneButton.AssociatedAction = new GameAction
	    {
	        Name = "Shoot a Scene",
	        Description = "Shoots a scene for your movie."
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
        var ShootRetakeButton = GameObject.Find("Shoot Retake Button").GetComponent<ActionsButton>();

        SceneButton.Enable();
        SceneButton.AssociatedAction.Allowed = true;

        ShootRetakeButton.Enable();
        ShootRetakeButton.AssociatedAction.Allowed = true;

        actionDisabledReason = String.Empty;
    }

    public GameAction SelectedAction;

    public string actionDisabledReason;

	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateTextLabels(GameAction associatedAction)
    {
        GameObject.Find("Action Name").GetComponent<UILabel>().text = associatedAction.Name;
        if (associatedAction.Allowed)
            GameObject.Find("Action Description").GetComponent<UILabel>().text = associatedAction.Description;
        else
            GameObject.Find("Action Description").GetComponent<UILabel>().text = associatedAction.Description
                + System.Environment.NewLine + System.Environment.NewLine + 
                "You are currently [i]not allowed[/i] to do this action!";

        if (!String.IsNullOrEmpty(actionDisabledReason))
            GameObject.Find("Action Description").GetComponent<UILabel>().text += actionDisabledReason;
    }
}
