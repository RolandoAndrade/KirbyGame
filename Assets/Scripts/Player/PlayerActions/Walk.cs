using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Walk : PlayerAction 
{
	private PlayerAction run = new Run();
	
	public bool Execute(Control player)
	{
		if (CrossPlatformInputManager.GetAxis ("Horizontal")!=0) 
		{
			if (CrossPlatformInputManager.GetAxis ("Run") > 0.5)
			{
				run.Execute (player);
			} 
			else 
			{
				Vector2 v = player.GetVelocity();
				v.x = player.GetHorizontalMovement() * player.walkSpeed;
				player.SetVelocity(v);
			}
			return true;
		}
		return false;
	}
}
