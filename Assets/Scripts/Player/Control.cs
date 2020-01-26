using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Control : MonoBehaviour 
{
	public float walkSpeed = 1f;
	public float runSpeed = 2f;

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
		this.Walk ();
	}

	void Walk()
	{
		this.animator.SetFloat ("velocityX", Mathf.Abs(this.body.velocity.x));
	}

	void Run()
	{
		
	}

	void FixedUpdate()
	{
		Vector2 movement = this.body.velocity; 
		movement.x = this.horizontalMovement * this.walkSpeed;
		this.body.velocity = movement;
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
