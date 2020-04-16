﻿using UnityEngine;

public abstract class PlayerState
{
	private Control player;

	public PlayerState(Control player)
	{
		this.player = player;
	}

	public PlayerState Execute()
	{
		PlayerState ps = this.ExecuteStateActions ();
		this.SetAnimations ();
		return ps;
	}
		
	public abstract PlayerState ExecuteStateActions();

	public abstract void SetAnimations();

	public Control GetPlayer()
	{
		return this.player;
	}
}
