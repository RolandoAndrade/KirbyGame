using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

	private GameObject parent;
	private Control playerControl;

	void Start () 
	{
		this.parent = this.transform.parent.gameObject;
		this.playerControl = parent.GetComponent<Food> ().player.GetComponent<Control>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		this.playerControl.Fill ();
		Destroy (this.parent);
	}
}
