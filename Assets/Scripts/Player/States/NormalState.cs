using UnityEngine;

public class NormalState : PlayerState 
{
	public NormalState(Control player, FlowFactory flowFactory):base(player, flowFactory)
	{

	}


	public override PlayerState ExecuteStateActions()
	{
		flowFactory.GetActionsFactory().GetWalk(player).Execute ();

		if (flowFactory.GetActionsFactory().GetJump(player).Execute ())
		{
			return flowFactory.GetStateFactory().GetJumpState(player, flowFactory);
		} 
		else if (flowFactory.GetActionsFactory().GetDown(player).Execute()) 
		{
			return flowFactory.GetStateFactory().GetDownState(player, flowFactory);
		}
		else if(flowFactory.GetStateFactory().GetEatState(player).Execute())
		{
			return flowFactory.GetActionsFactory ().GetEat (player, flowFactory);
		}
		return this;
	}

	public override void SetAnimations()
	{
		player.SetBoolAnimation ("isDownded", false);
		player.SetBoolAnimation ("isFlying", false);
	}
}
