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
	
	}

    public Days GetCurrentDay()
    {
        return DayOfWeek;
    }

    public void NextDay()
    {
        Debug.Log("Day incremented!");
        if (DayOfWeek == Days.Saturday)
            Week++;
        
        DayOfWeek++;
       
        Application.LoadLevel("DayTitleCard");
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
