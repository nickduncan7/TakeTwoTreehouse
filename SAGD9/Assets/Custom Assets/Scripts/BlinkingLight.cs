using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour {
    private GUIText guitext;
    private Color color;

	// Use this for initialization
	void Start () {
        guitext = this.GetComponent<GUIText>();
        color = guitext.color;
        StartCoroutine(Blink());
	}
	
    IEnumerator Blink()
    {
        for (int i = 0; i < 10; i++)
        {
            guitext.color = new Color(color.r, color.g, color.b, 0);
            yield return new WaitForSeconds(0.5f);
            guitext.color = new Color(color.r, color.g, color.b, 255);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
