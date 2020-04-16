using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Eat : PlayerAction 
{
	public Eat(Control player):base(player){}

	public override bool Execute()
	{
		if (CrossPlatformInputManager.GetButton ("Absorb")) 
		{
			return true;
		}
		return false;
	}
}
