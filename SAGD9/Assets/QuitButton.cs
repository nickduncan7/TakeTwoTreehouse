using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPress(bool pressed)
    {
        if (pressed) Application.Quit();
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
