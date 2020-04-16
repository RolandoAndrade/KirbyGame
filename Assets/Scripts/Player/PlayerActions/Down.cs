using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Down : PlayerAction 
{
	public Down (Control player) : base (player){}

	public override bool Execute()
	{
		if (CrossPlatformInputManager.GetButton ("Down")) 
		{
			GetPlayer().SetGravityScale(GetPlayer().defaultGravityScale);
			return true;
		}
		return false;
	}
}