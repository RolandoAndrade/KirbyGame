using UnityEngine;

public class NormalState : PlayerState 
{
	public NormalState(Control player, FlowFactory flowFactory):base(player, flowFactory)
	{

	}


	public override PlayerState ExecuteStateActions()
	{
		if (flowFactory.GetActionsFactory ().GetWalk (player).Execute ()) 
		{
			flowFactory.GetActionsFactory ().GetRun (player).Execute ();
		}
		if (flowFactory.GetActionsFactory().GetJump(player).Execute ())
		{
			return flowFactory.GetStateFactory().GetJumpState(player, flowFactory);
		} 
		else if (flowFactory.GetActionsFactory().GetDown(player).Execute()) 
		{
			return flowFactory.GetStateFactory().GetDownState(player, flowFactory);
		}
		else if(flowFactory.GetActionsFactory().GetEat(player).Execute())
		{
			return flowFactory.GetStateFactory ().GetEatState (player, flowFactory);
		}
		return this;
	}

	public override void SetAnimations()
	{
		player.SetBoolAnimation (StateConstant.IS_DOWNDED_ANIMATION, false);
		player.SetBoolAnimation (StateConstant.IS_FLIYING_ANIMATION, false);
	}
}
