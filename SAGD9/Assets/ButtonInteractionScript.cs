using Assets.Custom_Assets.Scripts.KidPicker;
using UnityEngine;
using System.Collections;

public class ButtonInteractionScript : MonoBehaviour
{

    public Sprite NormalSprite;
    public Sprite HoverSprite;
    public Sprite ClickSprite;

    private UI2DSprite mySprite;

    private bool canInteract = true;

	// Use this for initialization
	void Start ()
	{
	    mySprite = GetComponent<UI2DSprite>();

            
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (GetComponent<KidContinueButton>())
	        canInteract = GetComponent<KidContinueButton>().Enabled;

	    if (GetComponent<SundayContinueScript>())
	        canInteract = GetComponent<SundayContinueScript>().Enabled;
	}

    void OnHover(bool hovering)
    {
        if (canInteract)
        {
            if (hovering)
                mySprite.sprite2D = HoverSprite;
            else
            {
                mySprite.sprite2D = NormalSprite;
            }
        }
    }

    void OnPress(bool pressed)
    {
        if (canInteract)
        {
            if (pressed) mySprite.sprite2D = ClickSprite;
        }
    }
}
