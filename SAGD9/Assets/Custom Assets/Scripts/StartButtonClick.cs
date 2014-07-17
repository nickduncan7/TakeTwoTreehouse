using UnityEngine;
using System.Collections;

public class StartButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Hi Dodgeball, the idiot sending you this screenshot clicked on the shitty looking sphere.");

        Application.LoadLevel("MowLawn");
    }
}
