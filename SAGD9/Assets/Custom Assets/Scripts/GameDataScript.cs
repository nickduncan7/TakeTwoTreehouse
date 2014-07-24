using System;
using System.Collections.Generic;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour {

    public float Money = 5.00f;
    public int Week = 1;
    public Days DayOfWeek;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (ConsecutiveDaysNotMowed >= 7)
            GroundPlayer();
	}

    public int ConsecutiveDaysNotMowed = 0;

    public bool IsGrounded;

    public void GroundPlayer()
    {
        IsGrounded = true;
        var actionManager = GameObject.Find("ActionManager");
        if (actionManager)
        {
            actionManager.GetComponent<ActionManager>().DisallowOutsideTasks("You're grounded!");
        }
    }

    public Days GetCurrentDay()
    {
        return DayOfWeek;
    }

    public void NextDay()
    {
        Debug.Log("Day incremented!");
        if (DayOfWeek == Days.Saturday)
        {
            DayOfWeek = Days.Sunday;
            Week++;
            Application.LoadLevel("DayTitleCard");
            return;
        }

        DayOfWeek++;
       
        Application.LoadLevel("DayTitleCard");
    }

    public List<Script> Week1Scripts()
    {
        return new List<Script>
        {
            new Script
            {
                Name = "Jerks",
                Budget = 5,
                Plot = 6,
                Action = 4,
                Effects = 3,
                Dilemma = (() =>
                {
                    
                })
            },
            new Script
            {
                Name = "Socky",
                Budget = 10,
                Plot = 5,
                Action = 5,
                Effects = 5
            },
            new Script
            {
                Name = "Untitled Movie",
                Budget = 5,
                Plot = 5,
                Action = 4,
                Effects = 5
            },
            new Script
            {
                Budget = 0,
                Name = "Little Brother's Script",
                Plot = 2,
                Action = 4,
                Effects = 3
            }
        };
    }

    public Script SelectedScript;

    public void UngroundPlayer()
    {
        IsGrounded = false;
        var actionManager = GameObject.Find("ActionManager");
        if (actionManager)
        {
            actionManager.GetComponent<ActionManager>().AllowOutsideTasks();
        }
    }
}

public enum Days
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}
