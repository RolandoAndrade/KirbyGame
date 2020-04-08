using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Eat : PlayerAction 
{
	public bool Execute(Control player)
	{
		if (CrossPlatformInputManager.GetButton ("Absorb")) 
		{
			return true;
		}
		return false;
	}
}
