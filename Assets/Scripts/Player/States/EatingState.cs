public class EatingState:PlayerState
{
	private PlayerAction eat = new Eat(GetPlayer());

	public EatingState (Control player):base(player)
	{
	}

	public override PlayerState ExecuteStateActions()
	{
		if (!eat.Execute (GetPlayer ())) 
		{
			this.GetPlayer ().SetEatingAnimation (false);
			return new NormalState (GetPlayer()); 
		}
		this.SetAnimations ();
		return this;
	}

	public override void SetAnimations()
	{
		this.GetPlayer ().SetEatingAnimation (true);
	}
}
