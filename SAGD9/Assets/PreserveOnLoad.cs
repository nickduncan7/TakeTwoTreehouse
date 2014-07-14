using UnityEngine;
using System.Collections;

public class PreserveOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Money = 5.00f;
        DontDestroyOnLoad(this);
	}

    public float Money;
	
	// Update is called once per frame
	void Update () {
	
	}
}
