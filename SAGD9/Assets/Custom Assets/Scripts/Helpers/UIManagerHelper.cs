using UnityEngine;

public static class UIManagerHelper
{
    public static UIManager GetUIManager()
    {
        return GameObject.Find("Interface").GetComponent<UIManager>();
    }
}

