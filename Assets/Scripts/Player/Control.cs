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
	public Transform detector;

	public static string EATING_PARTICLES_NAME = "EatingParticles";
	private Rigidbody2D body;

	private bool isFlipped = false;
	private bool isGrounded = false;
	private bool isFull = false;

	private float horizontalMovement = 0f;
	private Animator animator;
	private GameObject eatingParticles;

	private PlayerState state;

	// Use this for initialization
	void Start () 
	{
		this.body = this.GetComponent<Rigidbody2D> ();
		this.animator = this.GetComponent<Animator> ();
		this.eatingParticles = this.transform.Find("EatingParticles").gameObject;
		this.state = new NormalState (this);
		this.SetEatingAnimation (false);
	}


	public void SetBoolAnimation(string name, bool active)
	{
		this.animator.SetBool (name, active);
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
		this.Flip ();
	}
		
	void FixedUpdate()
	{
		this.isGrounded = Physics2D.OverlapCircle (detector.position, 0.15f, floorMask);
		this.state = state.ExecuteStateActions ();
		this.animator.SetFloat ("velocityX", Mathf.Abs(this.body.velocity.x));
		this.animator.SetFloat ("velocityY", this.body.velocity.y);
		this.animator.SetBool ("isGrounded", this.isGrounded);
	}

	public void SetEatingAnimation(bool isEating)
	{
		this.SetBoolAnimation ("isEating", isEating);
		this.eatingParticles.SetActive(isEating);
	}

	void Flip()
	{
		if (this.isFlipped && this.horizontalMovement > 0 || !this.isFlipped && this.horizontalMovement < 0) 
		{
			this.isFlipped = !this.isFlipped;
			this.transform.localScale=new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
		}
	}

	public void Fill()
	{
		this.isFull = true;
		this.animator.SetBool ("isFull", this.isFull);
	}

	public PlayerState GetState()
	{
		return this.state;
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

	public void SetGravityScale(float gravityScale)
	{
		this.body.gravityScale = gravityScale;
	}

	public bool IsGrounded()
	{
		return this.isGrounded;
	}
}
