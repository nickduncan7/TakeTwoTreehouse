using UnityEngine;
using System.Collections;

public class TriggeredFader : MonoBehaviour
{

    private bool fadeToClear = false;
    private bool fadeToBlack = false;

    private float fadeSpeed = 1.5f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void OnGUI () {
	    if (fadeToClear)
            FadeClear();
        if (fadeToBlack)
            FadeBlack();
	}


    private void FadeClear()
    {
  
        // Lerp the colour of the texture between itself and transparent.
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    private void FadeBlack()
    {
        // Lerp the colour of the texture between itself and black.
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    public void FadeToClear()
    {
        fadeToBlack = false;
        fadeToClear = true;
    }


    public void FadeToBlack()
    {
        fadeToClear = false;
        fadeToBlack = true;
    }

    public bool ClearTransitionComplete()
    {
        return guiTexture.color.a <= 0.09;
    }

    public bool BlackTransitionComplete()
    {
        return guiTexture.color.a >= 0.91;
    }
}
