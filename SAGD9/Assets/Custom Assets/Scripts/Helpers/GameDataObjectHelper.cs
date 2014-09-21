using System;
using System.Collections.Generic;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;

public static class GameDataObjectHelper
{
    public static GameDataScript GetGameData()
    {
        try
        {
            return GameObject.Find("GameDataObject").GetComponent<GameDataScript>();

        }
        catch
        {
            
            GameObject.Find("UI Root").AddComponent<GameDataScript>();
            var gdo = GameObject.Find("UI Root").GetComponent<GameDataScript>();

            gdo.Cast = new List<Kid> { new Kid { Name = "Tomika", Acting = 1, Production = 2, Availability = new List<Days>{Days.Monday}}
                , new Kid { Name = "Daniel", Acting = 2, Production = 1, Availability = new List<Days>{Days.Monday}} };
            gdo.DayOfWeek = Days.Monday;
            gdo.SelectedScript = new Script {Action = 3, Budget = 0, Effects = 3, Plot = 3, GainedAction = 1, GainedEffects = 0, GainedPlot = 2};

            return gdo;
        }
    }
}

