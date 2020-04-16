using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Run : PlayerAction 
{
	public Run (Control player) : base (player){}

	public override bool Execute()
	{
		Vector2 v = GetPlayer().GetVelocity();
		v.x = GetPlayer().GetHorizontalMovement() * GetPlayer().runSpeed;
		GetPlayer().SetVelocity(v);
		return true;
	}
}
