using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Jump : PlayerAction 
{
	public Jump (Control player) : base (player){}

	public override bool Execute()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Jump")) 
		{
			Vector2 v = GetPlayer().GetVelocity();
			v.y = GetPlayer().jumpForce;
			GetPlayer().SetVelocity(v);
			GetPlayer ().PlaySound ("jump");
			return true;
		}
		return false;
	}
}
