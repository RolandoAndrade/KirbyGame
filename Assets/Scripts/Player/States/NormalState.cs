using UnityEngine;

public class NormalState : PlayerState 
{
	private PlayerAction jump = new Jump (GetPlayer());
	private PlayerAction walk = new Walk (GetPlayer());
	private PlayerAction down = new Down(GetPlayer());
	private PlayerAction eat = new Eat(GetPlayer());

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
		else if(eat.Execute(GetPlayer()))
		{
			return new EatingState (GetPlayer());
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
