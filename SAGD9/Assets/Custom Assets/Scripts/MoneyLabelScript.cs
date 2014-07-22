using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class MoneyLabelScript : MonoBehaviour
{
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
        if (gameDataScript)
            this.GetComponent<UILabel>().text = gameDataScript.Money.ToString("C0");
    }
}
