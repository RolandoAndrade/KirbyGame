using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Control : MonoBehaviour 
{
	public float walkSpeed = 1f;
	public float runSpeed = 2f;

	private SpriteRenderer spriteRenderer;
	public bool isFlipped = false;
	private bool isGrounded = false;
	// Use this for initialization
	void Start () 
	{
		this.spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
	}

	void Flip()
	{
		this.isFlipped = !this.isFlipped;
		this.spriteRenderer.flipX = this.isFlipped;
	}
}
