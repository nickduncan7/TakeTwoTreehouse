using System;
using System.Collections.Generic;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour {

    public float Money = 5.00f;
    public int Week = 1;
    public Days DayOfWeek;

    public int Fans = 0;

    public List<Kid> Cast; 

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
                    GroundPlayer();
                }),
                DilemmaDescription = "Your parents read through some of the movie script, and are not very happy to read a few choice words. You have been [i]GROUNDED![/i]"
                
            },
            new Script
            {
                Name = "Socky",
                Budget = 10,
                Plot = 5,
                Action = 5,
                Effects = 5,
                Dilemma = (() =>
                {
                    if (Money < 5)
                        Money = 0;
                    else
                        Money -= 5;
                   
                }),
                DilemmaDescription = "A few cast members forgot socks today! You use some of your money to buy more."
            },
            new Script
            {
                Name = "Weakday",
                Budget = 5,
                Plot = 5,
                Action = 4,
                Effects = 5,
                DilemmaDescription = "The scene you had hoped to record today is extremely graphic, and your entire cast does not want to participate. You will not be able to record a scene today.",
                Dilemma = () => Cast.ForEach(kid =>
                    kid.Availability.Remove(Days.Wednesday)
                    )
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
