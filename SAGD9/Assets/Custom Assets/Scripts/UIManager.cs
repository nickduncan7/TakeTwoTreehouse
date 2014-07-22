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

        title.GetComponent<UILabel>().text = NewText;
    }

    public void UpdateSubTitleText(string NewText)
    {
        var subtitle = GameObject.Find("SubTitleLabel");

        subtitle.GetComponent<UILabel>().text = '-' + NewText + '-';
    }
}
