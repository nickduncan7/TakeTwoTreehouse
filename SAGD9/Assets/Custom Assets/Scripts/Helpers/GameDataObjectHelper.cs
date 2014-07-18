using UnityEngine;

public static class GameDataObjectHelper
{
    public static GameDataScript GetGameData()
    {
        return GameObject.Find("GameDataObject").GetComponent<GameDataScript>();
    }
}

