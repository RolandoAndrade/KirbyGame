using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Fly : PlayerAction 
{
	public Fly(Control player):base(player){}

	public override bool Execute()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Jump"))
		{
			Vector2 v = GetPlayer().GetVelocity ();
			v.y = GetPlayer().flyForce;
			GetPlayer().SetVelocity(v);
			GetPlayer().SetGravityScale(GetPlayer().gravityFlying);
			return true;
		}
		return false;
	}
}