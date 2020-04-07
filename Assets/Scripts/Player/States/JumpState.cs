public class JumpState:PlayerState
{
	private PlayerAction fly= new Fly ();
	private PlayerAction walk = new Walk ();
	private PlayerAction down = new Down();

	public JumpState (Control player):base(player)
	{
	}

	public override void SetInitialState()
	{
		this.SetIsGrounded (false);
		this.SetIsDownded (false);
		this.SetIsFlying (false);
		this.SetIsEating (false);
		this.SetIsFull (false);
	}

	public override PlayerState ExecuteStateActions()
	{
		fly.Execute (GetPlayer());
		walk.Execute (GetPlayer());
		down.Execute (GetPlayer());
		return this;
	}

	public override void SetAnimations()
	{
		this.GetPlayer ().SetBoolAnimation ("isDownded", false);
	}
}

