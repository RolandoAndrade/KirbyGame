using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Down : PlayerAction 
{
	public bool Execute(Control player)
	{
		if (CrossPlatformInputManager.GetButton ("Down")) 
		{
			player.SetIsDownded (true);
			player.SetIsFlying(false);
			player.SetGravityScale(player.defaultGravityScale);
			return true;
		}
		return false;
	}
}