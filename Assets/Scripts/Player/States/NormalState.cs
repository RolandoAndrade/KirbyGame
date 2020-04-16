using UnityEngine;

public class NormalState : PlayerState 
{
	public NormalState(Control player):base(player)
	{

	}


	public override PlayerState ExecuteStateActions()
	{
		walk.Execute ();
		if (jump.Execute ())
		{
			return GetStateFactory().GetJumpState ();
		} 
		else if (down.Execute ()) 
		{
			return GetStateFactory().GetDownState();
		}
		else if(eat.Execute())
		{
			return GetStateFactory().GetEatState();
		}
		return this;
	}

	public override void SetAnimations()
	{
		this.GetPlayer ().SetBoolAnimation ("isDownded", false);
		this.GetPlayer ().SetBoolAnimation ("isFlying", false);
	}
}
