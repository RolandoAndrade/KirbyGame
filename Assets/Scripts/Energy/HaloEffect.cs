using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloEffect : MonoBehaviour {

	public float speed = 0.01f;
	private Light halo;
	private float ang = 0;
	// Use this for initialization
	void Start () 
	{
		this.halo = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ang = (ang + speed) % (Mathf.PI);
		this.halo.range = 5 + 2*Mathf.Sin (ang);
	}
}
