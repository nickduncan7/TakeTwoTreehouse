using UnityEngine;
using System.Collections;

public class TextureFilterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.mainTexture.filterMode = FilterMode.Point;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
