public interface StateFactory 
{
	PlayerState GetNormalState(Control player, FlowFactory flowFactory);

	PlayerState GetJumpState(Control player, FlowFactory flowFactory);

	PlayerState GetDownState(Control player, FlowFactory flowFactory);

	PlayerState GetEatState(Control player, FlowFactory flowFactory);

	PlayerState GetLandState(Control player, FlowFactory flowFactory);

	PlayerState GetFlyingState(Control player, FlowFactory flowFactory);
}
