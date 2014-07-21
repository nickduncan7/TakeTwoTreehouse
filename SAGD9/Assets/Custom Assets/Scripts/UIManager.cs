using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateTitleText(string NewText)
    {
        var title = GameObject.Find("TitleLabel");
        var shadow = GameObject.Find("TitleLabelShadow");

        title.guiText.text = NewText;
        shadow.guiText.text = NewText;
    }

    public void UpdateSubTitleText(string NewText)
    {
        var subtitle = GameObject.Find("SubTitleLabel");
        var shadow = GameObject.Find("SubTitleLabelShadow");

        subtitle.guiText.text = '-' + NewText + '-';
        shadow.guiText.text = '-' + NewText + '-';
    }
}
