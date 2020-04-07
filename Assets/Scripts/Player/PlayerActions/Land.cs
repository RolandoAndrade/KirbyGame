using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Land : PlayerAction 
{
	public bool Execute(Control player)
	{
		if (player.IsGrounded()) 
		{
			player.SetGravityScale(player.defaultGravityScale);
			return true;
		}
		return false;
	}
}