using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {
    private float startWaitTime = 2f;
    private float timeActive = 11f;
    private float timeToEnd = 3f;
    private float timer;
    private float fadeSpeed = 0.7f;

    // Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void OnGUI ()
	{
	    timer += Time.deltaTime;
        Debug.Log(timer);

        if (timer >= startWaitTime)
            FadeToClear();
        if (timer >= startWaitTime + timeActive)
            FadeToBlack();
        if (timer >= startWaitTime + timeActive + timeToEnd)
            Application.LoadLevel("MowLawn");

	}

    void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);

    }
}
