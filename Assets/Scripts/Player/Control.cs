using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Control : MonoBehaviour 
{
	public float walkSpeed = 1f;
	public float runSpeed = 5f;
	public float jumpForce = 10f;
	public float flyForce = 5f;
	public LayerMask floorMask;
	public float defaultGravityScale = 5f;
	public float gravityFlying = 1f;

	private SpriteRenderer spriteRenderer;
	private Rigidbody2D body;
	public Transform detector;

	private bool isFlipped = false;
	private bool isGrounded = false;
	private bool isDownded = false;
	private bool isFlying = false;
	private bool isEating = false;
	private bool isFull = false;

	private float horizontalMovement = 0f;
	private float verticalMovement = 0f;
	private Animator animator;
	private GameObject eatingParticles;

	private PlayerAction jump = new Jump ();
	private PlayerAction walk = new Walk ();


	// Use this for initialization
	void Start () 
	{
		this.spriteRenderer = this.GetComponent<SpriteRenderer> ();
		this.body = this.GetComponent<Rigidbody2D> ();
		this.animator = this.GetComponent<Animator> ();
		this.eatingParticles = this.transform.Find("EatingParticles").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
		this.verticalMovement = CrossPlatformInputManager.GetAxis("Vertical");
		this.Flip ();
	}

	void Walk()
	{
		Vector2 v = this.body.velocity;
		v.x = this.horizontalMovement * (CrossPlatformInputManager.GetAxis("Run")>0.5?this.runSpeed:this.walkSpeed);
		this.body.velocity = v;
	}

	void HorizontalMovement()
	{
		if (!this.isDownded&&!this.isEating)
		{
			this.Walk ();
		}
		this.animator.SetFloat ("velocityX", Mathf.Abs(this.body.velocity.x));
	}

	void VerticalMovement()
	{
		this.isDownded = false;
		jump.Execute (this);
		this.Fly ();
		this.Land ();

		this.animator.SetFloat ("velocityY", this.body.velocity.y);
		this.animator.SetBool ("isGrounded", this.isGrounded);
		this.animator.SetBool ("isFlying", this.isFlying);
	}

	void Actions()
	{
		this.Down ();
		this.Absorb ();

		this.animator.SetBool ("isEating", this.isEating);
		this.animator.SetBool ("isDownded", this.isDownded);
	}

	void FixedUpdate()
	{
		this.HorizontalMovement ();
		this.VerticalMovement ();
		this.Actions ();
	}

	void Fly()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Jump") && !this.isGrounded)
		{
			Vector2 v = this.body.velocity;
			v.y = this.flyForce;
			this.body.velocity = v;
			this.isFlying = true;
			this.body.gravityScale = this.gravityFlying;
		}
	}

	void Down()
	{
		if (CrossPlatformInputManager.GetButton ("Down")) 
		{
			this.isDownded = true;
			this.isFlying = false;
			this.body.gravityScale = this.defaultGravityScale;
		}
	}

	void Jump()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Jump") && this.isGrounded && !this.isFlying) 
		{
			Vector2 v = this.body.velocity;
			v.y = this.jumpForce;
			this.body.velocity = v;
		}

	}

	void Land()
	{
		this.isGrounded = Physics2D.OverlapCircle (detector.position, 0.5f, floorMask);
		if (this.isGrounded) 
		{
			this.body.gravityScale = this.defaultGravityScale;
			this.isFlying = false;
		}
	}

	void Absorb()
	{
		if (CrossPlatformInputManager.GetButton ("Absorb")&&!this.isFlying&&!this.isDownded&&!this.isFull) 
		{
			this.isEating = true;
		} 
		else 
		{
			this.isEating = false;
		}
		this.eatingParticles.SetActive(this.isEating);
	}

	void Flip()
	{
		if (this.isFlipped && this.horizontalMovement > 0 || !this.isFlipped && this.horizontalMovement < 0) 
		{
			this.isFlipped = !this.isFlipped;
			this.transform.localScale=new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
		}
	}

	public bool isAbsorbing()
	{
		return this.isEating;
	}

	public bool isCorrectEatingDirection(float x)
	{
		return this.transform.position.x > x == this.isFlipped;
	}

	public void Fill()
	{
		this.isFull = true;
		this.isEating = false;
		this.animator.SetBool ("isFull", this.isFull);
		this.animator.SetBool ("isEating", this.isEating);
	}

	//REFACTORING

	public bool IsFlying()
	{
		return this.isFlying;
	}

	public bool IsGrounded()
	{
		return this.isGrounded;
	}

	public bool IsEating()
	{
		return this.isEating;
	}

	public bool IsDownded()
	{
		return this.isDownded;
	}

	public Vector2 GetVelocity()
	{
		return this.body.velocity;
	}

	public float GetHorizontalMovement()
	{
		return this.horizontalMovement;
	}


	public void SetVelocity(Vector2 velocity)
	{
		this.body.velocity = velocity;
	}
}
