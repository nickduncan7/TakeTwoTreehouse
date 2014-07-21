using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GameObject.Find("Fader").GetComponent<TriggeredFader>().FadeToClear();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
