using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;

public class ActionsButton : MonoBehaviour
{

    public bool IsEnabled;

    private UIWidget controllerWidget;
    private UI2DSprite selectionArrowSprite;
    private bool isSelected;

    public Action AssociatedAction;

    // Use this for initialization
	void Start ()
	{
	    controllerWidget = this.GetComponent<UIWidget>();
	    if (!IsEnabled)
	        controllerWidget.alpha = 0.5f;
        else
            controllerWidget.alpha = 1f;
	}

    public void Enable()
    {
        IsEnabled = true;
        controllerWidget.alpha = 1f;
    }

    public void Disable()
    {
        IsEnabled = false;
        controllerWidget.alpha = 0.5f;
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    public void Deselect()
    {
        isSelected = false;
    }


    public void SelectMe()
    {
        GameObject.Find("Shoot Scene Button").GetComponent<ActionsButton>().Deselect();
        GameObject.Find("Mow Lawn Button").GetComponent<ActionsButton>().Deselect();
        GameObject.Find("Post Process Button").GetComponent<ActionsButton>().Deselect();
        GameObject.Find("Shoot Retake Button").GetComponent<ActionsButton>().Deselect();
        this.isSelected = true;
        var SelectionArrow = GameObject.Find("SelectionArrow");
        SelectionArrow.GetComponent<UI2DSprite>().SetAnchor(gameObject);
        SelectionArrow.GetComponent<UI2DSprite>().UpdateAnchors();

        GameObject.Find("ActionManager").GetComponent<ActionManager>().SelectedAction = this.AssociatedAction;

        GameObject.Find("Action Name").GetComponent<UILabel>().text = AssociatedAction.Name;
        GameObject.Find("Action Description").GetComponent<UILabel>().text = AssociatedAction.Description;


    }
	
	// Update is called once per frame
    void OnPress(bool pressed)
    {
        if (pressed && IsEnabled)
        {
            SelectMe();
        }
    }
}
