using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;

public class ActionsButton : MonoBehaviour
{

    public bool IsEnabled;

    private UIWidget controllerWidget;
    private UI2DSprite selectionArrowSprite;
    private bool isSelected;

    public GameAction AssociatedAction;

    // Use this for initialization
	void Start ()
	{
	    controllerWidget = this.GetComponent<UIWidget>();
	    if (!IsEnabled)
	    {
	        controllerWidget.alpha = 0.5f;
	    }
	    else
	    {
	        controllerWidget.alpha = 1f;
	    }
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
        GameObject.Find("ActionManager").GetComponent<ActionManager>().UpdateTextLabels(AssociatedAction);


    }
	
	// Update is called once per frame
    void OnPress(bool pressed)
    {
        if (pressed && IsEnabled)
        {
            SelectMe();
        }
    }

    void OnHover(bool hovering)
    {
        if (hovering)
        {
            var HoverArrow = GameObject.Find("HoverArrow");
            HoverArrow.GetComponent<UI2DSprite>().color = new Color(1f, 1f, 1f, 0.5f);
            HoverArrow.GetComponent<UI2DSprite>().SetAnchor(gameObject);
            HoverArrow.GetComponent<UI2DSprite>().UpdateAnchors();
            GameObject.Find("ActionManager").GetComponent<ActionManager>().UpdateTextLabels(AssociatedAction);
        }
        else
        {
            var HoverArrow = GameObject.Find("HoverArrow");
            HoverArrow.GetComponent<UI2DSprite>().color = new Color(1f, 1f, 1f, 0f);

            if (GameObject.Find("Shoot Scene Button").GetComponent<ActionsButton>().IsSelected())
                GameObject.Find("ActionManager").GetComponent<ActionManager>().UpdateTextLabels(
                    GameObject.Find("Shoot Scene Button").GetComponent<ActionsButton>().AssociatedAction
                    );
            if (GameObject.Find("Mow Lawn Button").GetComponent<ActionsButton>().IsSelected())
                GameObject.Find("ActionManager").GetComponent<ActionManager>().UpdateTextLabels(
                    GameObject.Find("Mow Lawn Button").GetComponent<ActionsButton>().AssociatedAction
                    );
            if (GameObject.Find("Post Process Button").GetComponent<ActionsButton>().IsSelected())
                GameObject.Find("ActionManager").GetComponent<ActionManager>().UpdateTextLabels(
                    GameObject.Find("Post Process Button").GetComponent<ActionsButton>().AssociatedAction
                    );
            if (GameObject.Find("Shoot Retake Button").GetComponent<ActionsButton>().IsSelected())
                GameObject.Find("ScriptManager").GetComponent<ActionManager>().UpdateTextLabels(
                    GameObject.Find("Shoot Retake Button").GetComponent<ActionsButton>().AssociatedAction
                    );
        }
    }

}
