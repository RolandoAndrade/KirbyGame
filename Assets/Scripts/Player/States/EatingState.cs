public class EatingState:PlayerState
{
	private bool isEating = true;

	public EatingState (Control player, FlowFactory flowFactory):base(player, flowFactory){}

	public override PlayerState ExecuteStateActions()
	{
		if (!flowFactory.GetActionsFactory().GetEat(player).Execute ()) 
		{
			this.isEating = false;
			return flowFactory.GetStateFactory ().GetNormalState (player, flowFactory);
		}
		return this;
	}

	public override void SetAnimations()
	{
		player.SetEatingAnimation (this.isEating);
	}
}
