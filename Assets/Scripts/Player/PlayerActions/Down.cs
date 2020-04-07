using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Down : PlayerAction 
{
	public bool Execute(Control player)
	{
		if (CrossPlatformInputManager.GetButton ("Down")) 
		{
			player.SetGravityScale(player.defaultGravityScale);
			return true;
		}
		return false;
	}
}