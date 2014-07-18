using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class MoneyLabelScript : MonoBehaviour
{
    public Rect Position;
    private GameDataScript gameDataScript;
	// Use this for initialization
	void Start ()
	{
        gameDataScript = GameDataObjectHelper.GetGameData();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        this.guiText.text = gameDataScript.Money.ToString("C2");
    }
}
