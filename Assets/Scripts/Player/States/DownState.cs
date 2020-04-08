public class DownState:PlayerState
{
	private PlayerAction down = new Down();

	public DownState (Control player):base(player)
	{
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
		this.GetPlayer ().SetBoolAnimation ("isFlying", false);
	}
}

