public class FlyingState : PlayerState 
{
	public FlyingState (Control player, FlowFactory flowFactory):base(player, flowFactory){}

	public override PlayerState ExecuteStateActions()
	{
		flowFactory.GetActionsFactory ().GetWalk (player).Execute ();
		flowFactory.GetActionsFactory ().GetFly (player).Execute ();
		if (flowFactory.GetActionsFactory ().GetDown (player).Execute ())
		{
			return flowFactory.GetStateFactory ().GetJumpState (player, flowFactory);
		} 
		else if (flowFactory.GetActionsFactory ().GetLand (player).Execute ())
		{
			return flowFactory.GetStateFactory ().GetNormalState (player, flowFactory);
		}
		this.SetAnimations ();
		return this;
	}

	public override void SetAnimations()
	{
		player.SetBoolAnimation (StateConstant.IS_DOWNDED_ANIMATION, false);
		player.SetBoolAnimation (StateConstant.IS_FLIYING_ANIMATION, true);
	}
}
