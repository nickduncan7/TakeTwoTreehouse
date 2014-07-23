using UnityEngine;

public static class FaderHelper
{
    public static void FadeToClear()
    {
        var fader = GameObject.Find("fader").GetComponent<TriggeredFader>();
        if (fader)
            fader.FadeToClear();
    }

    public static void FadeToBlack()
    {
        var fader = GameObject.Find("fader").GetComponent<TriggeredFader>();
        if (fader)
            fader.FadeToBlack();
    }

    public static bool ClearTransitionComplete()
    {
        var fader = GameObject.Find("fader").GetComponent<TriggeredFader>();
        if (fader)
            return fader.ClearTransitionComplete();
         return false;
    }

    public static bool BlackTransitionComplete()
    {
        var fader = GameObject.Find("fader").GetComponent<TriggeredFader>();
        if (fader)
            return fader.BlackTransitionComplete();
        return false;
    }
}

