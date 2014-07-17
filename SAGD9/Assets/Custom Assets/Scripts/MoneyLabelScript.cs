using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class MoneyLabelScript : MonoBehaviour
{
    public Rect Position;
    private GameObject gameDataGameObject;
    private GameDataScript gameDataScript;
	// Use this for initialization
	void Start ()
	{
	    gameDataGameObject = GameObject.Find("GameDataObject");
	    gameDataScript = gameDataGameObject.GetComponent<GameDataScript>();
        Debug.Log(gameDataScript.Money);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        this.guiText.text = gameDataScript.Money.ToString("C2");
    }
}
