using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {

    public float moveSpeed = 5f;
    public Transform Background;
    private Animator animator;
    // Use this for initialization
	void Start ()
	{
	    animator = this.GetComponent<Animator>();
	}

    // Update is called once per frame
	void FixedUpdate () {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");


	    if (GetComponent<Rigidbody2D>().velocity != new Vector2(moveHorizontal*moveSpeed, moveVertical*moveSpeed))
	    {
            animator.SetBool("Idle", false);
	        GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity,
	            new Vector2(moveHorizontal*moveSpeed, moveVertical*moveSpeed), 1);
            Background.position = new Vector3(transform.position.x / 3f, transform.position.y / 3f, 40f);
	    }

        if (GetComponent<Rigidbody2D>().velocity == new Vector2(0f, 0f))
            animator.SetBool("Idle", true);

        if (GetComponent<Rigidbody2D>().velocity.x < 0)
            animator.SetBool("FacingLeft", true);
        else if (GetComponent<Rigidbody2D>().velocity.x > 0)
            animator.SetBool("FacingLeft", false);

	}
}
