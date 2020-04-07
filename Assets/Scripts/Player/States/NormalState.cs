using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : PlayerState 
{
	private PlayerAction jump = new Jump ();
	private PlayerAction walk = new Walk ();
	private PlayerAction down = new Down();

	public NormalState(Control player):base(player)
	{
		
	}

	public override void SetInitialState()
	{
		this.SetIsGrounded (true);
		this.SetIsDownded (false);
		this.SetIsFlying (false);
		this.SetIsEating (false);
		this.SetIsFull (false);
	}

	public override PlayerState ExecuteStateActions()
	{
		jump.Execute (GetPlayer());
		walk.Execute (GetPlayer());
		down.Execute (GetPlayer());
		return this;
	}
}
