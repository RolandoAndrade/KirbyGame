using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : PlayerState 
{
	private PlayerAction jump = new Jump ();
	private PlayerAction walk = new Walk ();
	private PlayerAction down = new Down();

	public PlayerState StateActions()
	{
		jump.Execute (GetPlayer());
		walk.Execute (GetPlayer());
		down.Execute (GetPlayer());
	}
}
