public class FlyingState : PlayerState 
{
	private PlayerAction fly= new Fly (GetPlayer());
	private PlayerAction walk = new Walk (GetPlayer());
	private PlayerAction down = new Down(GetPlayer());
	private PlayerAction land = new Land (GetPlayer());

	public FlyingState (Control player):base(player)
	{
	}

	public override PlayerState ExecuteStateActions()
	{
		walk.Execute (GetPlayer());
		fly.Execute (GetPlayer ());
		if (down.Execute(GetPlayer())) 
		{
			return new JumpState (GetPlayer());
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
		this.GetPlayer ().SetBoolAnimation ("isFlying", true);
	}
}
