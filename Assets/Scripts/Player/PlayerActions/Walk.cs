using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Walk : PlayerAction 
{
	public Walk(Control player):base(player){}
	
	public override bool Execute()
	{
		if (CrossPlatformInputManager.GetAxis ("Horizontal")!=0) 
		{
			if (CrossPlatformInputManager.GetAxis ("Run") < 0.5)
			{
				Vector2 v = GetPlayer().GetVelocity();
				v.x =  GetPlayer().GetHorizontalMovement() *  GetPlayer().walkSpeed;
				GetPlayer().SetVelocity(v);
			}
			return true;
		}
		return false;
	}
}
