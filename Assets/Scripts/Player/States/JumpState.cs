public class JumpState:PlayerState
{
	private PlayerAction fly= new Fly ();
	private PlayerAction walk = new Walk ();
	private PlayerAction land = new Land ();

	public JumpState (Control player):base(player)
	{
	}

	public override PlayerState ExecuteStateActions()
	{
		walk.Execute (GetPlayer());
		if (fly.Execute (GetPlayer ())) 
		{
			return new FlyingState (GetPlayer ());
		}
		else if(land.Execute(GetPlayer()))
		{
			return new NormalState (GetPlayer ());
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

