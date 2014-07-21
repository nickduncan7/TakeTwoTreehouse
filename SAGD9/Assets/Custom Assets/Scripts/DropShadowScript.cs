using UnityEngine;
using System.Collections;

public class DropShadowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var shadow = Instantiate(this, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), new Quaternion()) as GameObject;
	    if (shadow)
	    {
	        shadow.guiText.pixelOffset = new Vector2(this.guiText.pixelOffset.x + 0.2f, this.guiText.pixelOffset.y + 0.2f);
	        shadow.guiText.color = Color.black;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
