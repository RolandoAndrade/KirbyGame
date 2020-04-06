using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Fly : PlayerAction 
{
	public bool Execute(Control player)
	{
		if (CrossPlatformInputManager.GetButtonDown ("Jump") && !player.IsGrounded())
		{
			Vector2 v = player.GetVelocity ();
			v.y = player.flyForce;
			player.SetVelocity(v);
			player.SetIsFlying(true);
			player.SetGravityScale(player.gravityFlying);
			return true;
		}
		return false;
	}
}