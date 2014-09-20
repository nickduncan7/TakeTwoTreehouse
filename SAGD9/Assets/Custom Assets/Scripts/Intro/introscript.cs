using UnityEngine;
using System.Collections;

public class introscript : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(Begin());
	}

    private IEnumerator Begin()
    {
        var fadein = TweenAlpha.Begin(GameObject.Find("Container"), 0.4f, 1.1f);
        fadein.PlayForward();

        yield return new WaitForSeconds(7);
        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        var fadein = TweenAlpha.Begin(GameObject.Find("Container"), 0.4f, -0.1f);
        fadein.PlayForward();
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel("DayTitleCard");
    }

    // Update is called once per frame
	void Update () {
	
	}
}
