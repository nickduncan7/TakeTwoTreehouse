using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {
    private float startWaitTime = 1.5f;
    private float timeActive = 9f;
    private float timeToEnd = 2f;
    private float timer;
    private float fadeSpeed = 1.5f;

    // Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void OnGUI ()
	{
	    timer += Time.deltaTime;
        if (timer >= startWaitTime)
            FadeToClear();
        if (timer >= startWaitTime + timeActive)
            FadeToBlack();
	    if (timer >= startWaitTime + timeActive + timeToEnd)
	    {
	        var gameDataScript = GameDataObjectHelper.GetGameData();

            if (gameDataScript.GetCurrentDay() == Days.Sunday)
	            Application.LoadLevel("Sunday");
            else if(gameDataScript.GetCurrentDay() == Days.Wednesday)
            {
                Application.LoadLevel("WednesdayDilemma");
            }
            else if(gameDataScript.GetCurrentDay() == Days.Saturday)
            {
                Application.LoadLevel("Saturday");
                
            }
            else
            {
                Application.LoadLevel("DailyChoice");
            }
	    }

	}

    void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);

    }
}
