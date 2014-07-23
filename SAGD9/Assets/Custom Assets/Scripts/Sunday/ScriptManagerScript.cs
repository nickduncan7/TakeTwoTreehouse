using System.Collections.Generic;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;

public class ScriptManagerScript : MonoBehaviour
{
    public Script CurrentlySelectedScript;
    private List<Script> WeekScripts; 
	// Use this for initialization
	void Start ()
	{
        
	    WeekScripts = GameDataObjectHelper.GetGameData().Week1Scripts();
        GameObject.Find("Script1").GetComponent<ScriptSelection>().AssociatedScript = WeekScripts[0];
        GameObject.Find("Script2").GetComponent<ScriptSelection>().AssociatedScript = WeekScripts[1];
        GameObject.Find("Script3").GetComponent<ScriptSelection>().AssociatedScript = WeekScripts[2];
        GameObject.Find("Brother").GetComponent<ScriptSelection>().AssociatedScript = WeekScripts[3];
        GameObject.Find("Script1").GetComponent<ScriptSelection>().SelectMe();
        GameObject.Find("fader").GetComponent<TriggeredFader>().FadeToClear();
	}

    public void UpdateTextLabels(Script selectedScript)
    {
        GameObject.Find("Movie Title").GetComponent<UILabel>().text = selectedScript.Name;

        if (selectedScript.Budget == 0)
            GameObject.Find("BudgetLabel").GetComponent<UILabel>().text = "Budget: Free";
        else
            GameObject.Find("BudgetLabel").GetComponent<UILabel>().text = "Budget: " + selectedScript.Budget.ToString("C0");

        GameObject.Find("PlotLabel").GetComponent<UILabel>().text = "Plot: " + selectedScript.Plot;
        GameObject.Find("ActionLabel").GetComponent<UILabel>().text = "Action: " + selectedScript.Action;
        GameObject.Find("EffectsLabel").GetComponent<UILabel>().text = "Effects: " + selectedScript.Effects;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
