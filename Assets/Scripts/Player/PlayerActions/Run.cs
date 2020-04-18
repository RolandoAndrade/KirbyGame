using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Run : PlayerAction 
{
	public Run (Control player) : base (player){}

	public override bool Execute()
	{
		if (CrossPlatformInputManager.GetAxis ("Run") > 0.5) 
		{
			Vector2 v = GetPlayer().GetVelocity();
			v.x = GetPlayer().GetHorizontalMovement() * GetPlayer().runSpeed;
			GetPlayer().SetVelocity(v);
			return true;
		}
		return false;
	}
}
