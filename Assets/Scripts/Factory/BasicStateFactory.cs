public class BasicStateFactory : StateFactory 
{
	public PlayerState GetNormalState(Control player, FlowFactory flowFactory)
	{
		return new NormalState (player, flowFactory);
	}

	public PlayerState GetJumpState(Control player, FlowFactory flowFactory)
	{
		return new JumpState (player, flowFactory);
	}
		
	public PlayerState GetDownState(Control player, FlowFactory flowFactory)
	{
		return new DownState (player, flowFactory);
	}

	public PlayerState GetEatState(Control player, FlowFactory flowFactory)
	{
		return new EatingState (player, flowFactory);
	}

	public PlayerState GetLandState(Control player, FlowFactory flowFactory)
	{
		return new Land (player, flowFactory);
	}

	public PlayerState GetFlyingState(Control player, FlowFactory flowFactory)
	{
		return new FlyingState (player, flowFactory);
	}
}
