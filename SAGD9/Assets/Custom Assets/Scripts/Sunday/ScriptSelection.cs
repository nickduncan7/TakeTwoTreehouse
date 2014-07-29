using System.Linq;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;

public class ScriptSelection : MonoBehaviour {
    private bool isSelected;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsSelected()
    {
        return isSelected;
    }

    public void Deselect()
    {
        isSelected = false;
    }

    public Script AssociatedScript;

    public void SelectMe()
    {
        GameObject.Find("Script1").GetComponent<ScriptSelection>().Deselect();
        GameObject.Find("Script2").GetComponent<ScriptSelection>().Deselect();
        GameObject.Find("Script3").GetComponent<ScriptSelection>().Deselect();
        GameObject.Find("Brother").GetComponent<ScriptSelection>().Deselect();
        this.isSelected = true;
        var SelectionArrow = GameObject.Find("SelectionArrow");
        SelectionArrow.GetComponent<UI2DSprite>().SetAnchor(gameObject);
        SelectionArrow.GetComponent<UI2DSprite>().UpdateAnchors();
        GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().UpdateTextLabels(AssociatedScript);
        GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().CurrentlySelectedScript = AssociatedScript;

        if (AssociatedScript.Budget > GameDataObjectHelper.GetGameData().Money)
        {
            GameObject.Find("ContinueButton").GetComponent<SundayContinueScript>().Disable();
        }
        else
        {
            GameObject.Find("ContinueButton").GetComponent<SundayContinueScript>().Enable();
        }

    }
    void OnPress(bool pressed)
    {
        if (pressed) SelectMe();
    }

    void OnHover(bool hovering)
    {
        if (hovering)
        {
            var HoverArrow = GameObject.Find("HoverArrow");
            HoverArrow.GetComponent<UI2DSprite>().color = new Color(1f, 1f, 1f, 0.5f);
            HoverArrow.GetComponent<UI2DSprite>().SetAnchor(gameObject);
            HoverArrow.GetComponent<UI2DSprite>().UpdateAnchors();
            GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().UpdateTextLabels(AssociatedScript);
            if (AssociatedScript.Budget > GameDataObjectHelper.GetGameData().Money)
            {
                GameObject.Find("ContinueButton").GetComponent<SundayContinueScript>().Disable();
            }
            else
            {
                GameObject.Find("ContinueButton").GetComponent<SundayContinueScript>().Enable();
            }
        }
        else
        {
            var HoverArrow = GameObject.Find("HoverArrow");
            HoverArrow.GetComponent<UI2DSprite>().color = new Color(1f, 1f, 1f, 0f);

            if (GameObject.Find("Script1").GetComponent<ScriptSelection>().IsSelected())
                GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().UpdateTextLabels(
                    GameObject.Find("Script1").GetComponent<ScriptSelection>().AssociatedScript
                    );
            if (GameObject.Find("Script2").GetComponent<ScriptSelection>().IsSelected())
                GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().UpdateTextLabels(
                    GameObject.Find("Script2").GetComponent<ScriptSelection>().AssociatedScript
                    );
            if (GameObject.Find("Script3").GetComponent<ScriptSelection>().IsSelected())
                GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().UpdateTextLabels(
                    GameObject.Find("Script3").GetComponent<ScriptSelection>().AssociatedScript
                    );
            if (GameObject.Find("Brother").GetComponent<ScriptSelection>().IsSelected())
                GameObject.Find("ScriptManager").GetComponent<ScriptManagerScript>().UpdateTextLabels(
                    GameObject.Find("Brother").GetComponent<ScriptSelection>().AssociatedScript
                    );
        }
    }
}
