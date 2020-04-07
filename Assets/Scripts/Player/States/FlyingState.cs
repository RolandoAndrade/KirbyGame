﻿using UnityEngine;

public class FlyingState : PlayerState 
{
	private PlayerAction fly= new Fly ();
	private PlayerAction walk = new Walk ();
	private PlayerAction down = new Down();
	private PlayerAction land = new Land ();

	public FlyingState (Control player):base(player)
	{
	}

	public override void SetInitialState()
	{
		this.SetIsGrounded (false);
		this.SetIsDownded (false);
		this.SetIsFlying (true);
		this.SetIsEating (false);
		this.SetIsFull (false);
	}

	public override PlayerState ExecuteStateActions()
	{
		Debug.Log ("Volar");
		walk.Execute (GetPlayer());
		fly.Execute (GetPlayer ());
		if (down.Execute(GetPlayer())) 
		{
			return new JumpState (GetPlayer());
		}
		else if(land.Execute(GetPlayer()))
		{
			return new NormalState (GetPlayer ());
		}
		this.SetAnimations ();
		return this;
	}

	public override void SetAnimations()
	{
		this.GetPlayer ().SetBoolAnimation ("isDownded", false);
		this.GetPlayer ().SetBoolAnimation ("isFlying", true);
	}
}