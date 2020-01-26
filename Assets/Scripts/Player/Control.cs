using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Control : MonoBehaviour 
{
	public float walkSpeed = 1f;
	public float runSpeed = 5f;

	private SpriteRenderer spriteRenderer;
	private Rigidbody2D body;

	private bool isFlipped = false;
	private bool isGrounded = false;
	private float horizontalMovement = 0f;
	private float verticalMovement = 0f;
	private Animator animator;
	// Use this for initialization
	void Start () 
	{
		this.spriteRenderer = this.GetComponent<SpriteRenderer> ();
		this.body = this.GetComponent<Rigidbody2D> ();
		this.animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
		this.Flip ();
	}

	void Walk()
	{
		this.Move (this.body.velocity);
		this.animator.SetFloat ("velocityX", Mathf.Abs(this.body.velocity.x));
	}

	void Move(Vector2 movement)
	{
		movement.x = this.horizontalMovement * (CrossPlatformInputManager.GetAxis("Run")>0.5?this.runSpeed:this.walkSpeed);
		this.body.velocity = movement;
	}

	void FixedUpdate()
	{
		Vector2 movement = this.body.velocity; 
		this.Walk ();


	}

	void Flip()
	{
		if (this.isFlipped && this.horizontalMovement > 0 || !this.isFlipped && this.horizontalMovement < 0) 
		{
			this.isFlipped = !this.isFlipped;
			this.spriteRenderer.flipX = this.isFlipped;
		}
	}
}
