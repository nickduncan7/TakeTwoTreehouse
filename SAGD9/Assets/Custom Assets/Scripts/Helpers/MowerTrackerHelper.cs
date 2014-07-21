using UnityEngine;

public static class MowerTrackerHelper
{
    public static MowerTracker GetMowerDataScript()
    {
        return GameObject.Find("MowerTracker").GetComponent<MowerTracker>();
    }
}

