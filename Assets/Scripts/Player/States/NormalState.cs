using UnityEngine;

public class NormalState : PlayerState 
{
	private PlayerAction jump = new Jump ();
	private PlayerAction walk = new Walk ();
	private PlayerAction down = new Down();

	public NormalState(Control player):base(player)
	{
		
	}


	public override PlayerState ExecuteStateActions()
	{
		walk.Execute (GetPlayer());
		if (jump.Execute (GetPlayer ()))
		{
			return new JumpState (GetPlayer());
		} 
		else if (down.Execute (GetPlayer ())) 
		{
			return new DownState (GetPlayer());
		}
		this.SetAnimations ();
		return this;
	}

	public override void SetAnimations()
	{
		this.GetPlayer ().SetBoolAnimation ("isDownded", false);
		this.GetPlayer ().SetBoolAnimation ("isFlying", false);
	}
}
