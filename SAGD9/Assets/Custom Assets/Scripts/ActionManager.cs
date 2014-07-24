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

	    SceneButton.AssociatedAction = new Action
	    {
	        Name = "Shoot a Scene",
	        Description = "Shoots a scene for your movie."
	    };
        MowButton.AssociatedAction = new Action
        {
            Name = "Do Chores",
            Description = "Mow the lawn to earn you money, and please your parents. If you don't do this regularly, you might get grounded!",
            LevelToLoad = "MowLawn"
        };
        PostProcessButton.AssociatedAction = new Action
        {
            Name = "Post Process a Scene",
            Description = "Do some editing to your existing scenes in order to improve the movies' Effects or Action score."
        };
        ShootRetakeButton.AssociatedAction = new Action
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

    public Action SelectedAction;
	
	// Update is called once per frame
	void Update () {
	
	}
}
