﻿using UnityEngine;
using System.Collections;

public class PreserveOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}

    
	
	// Update is called once per frame
	void Update () {
	
	}
}