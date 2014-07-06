using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

    public float moveSpeed = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        rigidbody2D.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);

	}
}
