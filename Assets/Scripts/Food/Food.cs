using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	public GameObject player;
	public float eatingSpeed = 5f;

	private Control playerControl;
	private bool isPlayerInEatingZone = false;
	private const float SPEED_DIVIDER = 10f;
	// Use this for initialization
	void Start () 
	{
		playerControl = player.GetComponent<Control> ();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		this.isPlayerInEatingZone = true;
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		this.isPlayerInEatingZone = false;
	}

	void HorizontalMovement()
	{
		int factor = this.transform.position.x > player.transform.position.x ? -1:1;
		Vector3 t = this.transform.position;
		t.x +=  this.eatingSpeed/SPEED_DIVIDER * factor;
		this.transform.position = t; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.isPlayerInEatingZone && this.playerControl.isAbsorbing () && this.playerControl.isCorrectEatingDirection(this.transform.position.x)) 
		{
			this.HorizontalMovement ();
		}
	}
}
