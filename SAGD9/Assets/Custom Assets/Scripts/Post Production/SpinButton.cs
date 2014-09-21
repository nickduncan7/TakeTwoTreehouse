using UnityEngine;
using System.Collections;

public class SpinButton : MonoBehaviour
{

    private bool activated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPress(bool pressed)
    {
        if (pressed && !activated)
        {
            GameObject.Find("PostProdManager").GetComponent<PostProductionManager>().DoStuff();
            activated = true;
        }
    }
}
