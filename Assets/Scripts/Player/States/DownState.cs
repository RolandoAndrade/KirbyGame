public class DownState:PlayerState
{
	public DownState (Control player, FlowFactory flowFactory):base(player, flowFactory)
	{
		player.PlaySound ("down");
	}
		
	public override PlayerState ExecuteStateActions()
	{
		if (!flowFactory.GetActionsFactory().GetDown(player).Execute ()) 
		{
			return flowFactory.GetStateFactory().GetNormalState(player, flowFactory); 
		}
		return this;
	}

	public override void SetAnimations()
	{
		player.SetBoolAnimation (StateConstant.IS_DOWNDED_ANIMATION, true);
		player.SetBoolAnimation (StateConstant.IS_FLIYING_ANIMATION, false);
	}
}

