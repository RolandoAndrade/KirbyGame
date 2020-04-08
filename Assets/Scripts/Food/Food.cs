using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour 
{

	public GameObject player;
	public float eatingSpeed = 5f;

	private Control playerControl;
	private const float SPEED_DIVIDER = 10f;

	private bool isMoving = false;

	// Use this for initialization
	void Start () 
	{
		playerControl = player.GetComponent<Control> ();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name == Control.EATING_PARTICLES_NAME) 
		{
			this.isMoving = true;
		} 
		else 
		{
			this.playerControl.Fill ();
			Destroy (this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.name == Control.EATING_PARTICLES_NAME) 
		{
			this.isMoving = false;
		}
	}

	void HorizontalMovement()
	{
		float distance = player.transform.position.x - this.transform.position.x;
		if (distance != 0) 
		{
			float factor = 1/distance;
			Vector3 t = this.transform.position;
			t.x +=  this.eatingSpeed/SPEED_DIVIDER * factor;
			this.transform.position = t;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.isMoving) 
		{
			this.HorizontalMovement ();
		}
	}
}
