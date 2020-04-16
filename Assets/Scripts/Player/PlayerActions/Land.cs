using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Land : PlayerAction 
{
	public Land(Control player):base(player){}

	public override bool Execute()
	{
		if (GetPlayer().IsGrounded()) 
		{
			GetPlayer().SetGravityScale(GetPlayer().defaultGravityScale);
			return true;
		}
		return false;
	}
}