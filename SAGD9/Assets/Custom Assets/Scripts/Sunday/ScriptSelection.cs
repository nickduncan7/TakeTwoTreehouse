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
    }
    void OnPress(bool pressed)
    {
        if (pressed) SelectMe();
    }
}
