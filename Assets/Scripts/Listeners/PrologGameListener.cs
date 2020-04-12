using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologGameListener : MonoBehaviour, GameListener 
{
	public Captions captions;

	public bool Listen ()
	{
		return captions.IsEnded ();
	}
}
