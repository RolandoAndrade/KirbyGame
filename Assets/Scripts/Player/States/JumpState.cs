using UnityEngine;

public class JumpState:PlayerState
{
	public JumpState (Control player, FlowFactory flowFactory):base(player, flowFactory){}

	public override PlayerState ExecuteStateActions()
	{
		flowFactory.GetActionsFactory().GetWalk(player).Execute ();
		if (flowFactory.GetActionsFactory().GetFly(player).Execute ()) 
		{
			return flowFactory.GetStateFactory().GetFlyingState(player, flowFactory);
		}
		else if(flowFactory.GetActionsFactory().GetLand(player).Execute())
		{
			return flowFactory.GetStateFactory().GetNormalState(player, flowFactory);
		}
		return this;
	}

	public override void SetAnimations()
	{
		player.SetBoolAnimation (StateConstant.IS_DOWNDED_ANIMATION, false);
		player.SetBoolAnimation (StateConstant.IS_FLIYING_ANIMATION, false);
	}
}

