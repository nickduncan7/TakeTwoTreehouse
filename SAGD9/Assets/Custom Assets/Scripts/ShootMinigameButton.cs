using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class ShootMinigameButton : MonoBehaviour
{
    public bool clicked;

	// Use this for initialization
	void Start ()
	{
	    clicked = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}


    void OnHover(bool hovering)
    {
        if (!clicked)
        {
            if (hovering)
            {
                transform.FindChild("Background").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                transform.FindChild("Background").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
            }
        }
    }

    void OnPress(bool pressed)
    {
        var manager = GameObject.Find("ShootMinigameManager").GetComponent<ShootMinigameManager>();

        if (pressed && !clicked && !manager.AnswerSelected)
        {
            clicked = true;
            manager.AnswerSelected = true;

            if (transform.FindChild("Label").GetComponent<UILabel>().text == manager.CurrentWord)
            {
                transform.FindChild("Background").GetComponent<UI2DSprite>().color = new Color(0, 1, 0, 1);
                manager.RecordSuccess(manager.CurrentKid);
            }
            else
            {
                {
                    manager.RecordFailure(manager.CurrentKid);
                    transform.FindChild("Background").GetComponent<UI2DSprite>().color = new Color(1, 0, 0, 1);
                }
            }
        }
    }
}
