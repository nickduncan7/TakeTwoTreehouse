using UnityEngine;
using System.Collections;

public class StartButtonClick : MonoBehaviour
{

    private bool MoveOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (MoveOn)
	    {
            if (GameObject.Find("Fader").GetComponent<TriggeredFader>().BlackTransitionComplete())
                Application.LoadLevel("DayTitleCard");
	    }
	}

    void OnMouseDown()
    {
        GameObject.Find("Fader").GetComponent<TriggeredFader>().FadeToBlack();
        MoveOn = true;

    }
}
