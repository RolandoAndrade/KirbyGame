using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Run : PlayerAction 
{
	public bool Execute(Control player)
	{
		Vector2 v = player.GetVelocity();
		v.x = player.GetHorizontalMovement() * player.runSpeed;
		player.SetVelocity(v);
		return true;
	}
}
