﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Jump : PlayerAction 
{
	public bool Execute(Control player)
	{
		if (CrossPlatformInputManager.GetButtonDown ("Jump") && player.IsGrounded() && !player.IsFlying()) 
		{
			Vector2 v = player.GetVelocity();
			v.y = player.jumpForce;
			player.SetVelocity(v);
			return true;
		}
		return false;
	}
}
