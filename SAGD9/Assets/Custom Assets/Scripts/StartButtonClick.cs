using UnityEngine;
using System.Collections;

public class StartButtonClick : MonoBehaviour
{

    private bool MoveOn = false;
    private bool transitionStarted;
    private float timer;

    // Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (transitionStarted)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                FaderHelper.FadeToBlack();
            }
            if (timer >= 5 && FaderHelper.BlackTransitionComplete())
            {
                Application.LoadLevel("DayTitleCard");
            }
        }
    }

    void OnPress(bool pressed)
    {
        if (pressed) SelectMe();
    }

    private void SelectMe()
    {
        transitionStarted = true;
    }

    void OnHover(bool hovering)
    {
        if (hovering)
        {
            var HoverArrow = GameObject.Find("HoverArrow");
            HoverArrow.GetComponent<UI2DSprite>().color = new Color(1f, 1f, 1f, 0.5f);
            HoverArrow.GetComponent<UI2DSprite>().SetAnchor(gameObject);
            HoverArrow.GetComponent<UI2DSprite>().UpdateAnchors();
        }
        else
        {
            var HoverArrow = GameObject.Find("HoverArrow");
            HoverArrow.GetComponent<UI2DSprite>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
