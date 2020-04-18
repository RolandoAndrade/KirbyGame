public class EatingState:PlayerState
{
	public EatingState (Control player, FlowFactory flowFactory):base(player, flowFactory){}

	public override PlayerState ExecuteStateActions()
	{
		if (!flowFactory.GetActionsFactory().GetEat(player).Execute ()) 
		{
			player.SetEatingAnimation (false);
			return flowFactory.GetStateFactory ().GetNormalState (player, flowFactory);
		}
		return this;
	}

	public override void SetAnimations()
	{
		player.SetEatingAnimation (true);
	}
}
