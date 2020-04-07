public class DownState:PlayerState
{
	private PlayerAction down = new Down();

	public DownState (Control player):base(player)
	{
	}

	public override void SetInitialState()
	{
		this.SetIsGrounded (false);
		this.SetIsDownded (true);
		this.SetIsFlying (false);
		this.SetIsEating (false);
		this.SetIsFull (false);
	}

	public override PlayerState ExecuteStateActions()
	{
		if (!down.Execute (GetPlayer ())) 
		{
			return new NormalState (GetPlayer()); 
		}
		this.SetAnimations ();
		return this;
	}

	public override void SetAnimations()
	{
		this.GetPlayer ().SetBoolAnimation ("isDownded", true);
	}
}

