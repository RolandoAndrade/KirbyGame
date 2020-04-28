using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallListener : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		this.GetComponent<NextScene> ().ChangeScene ();
	}
}
