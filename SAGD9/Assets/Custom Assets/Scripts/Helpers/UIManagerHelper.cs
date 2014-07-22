using UnityEngine;

public static class UIManagerHelper
{
    public static UIManager GetUIManager()
    {
        return GameObject.Find("UI Root").GetComponent<UIManager>();
    }
}

