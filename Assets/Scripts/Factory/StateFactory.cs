public interface StateFactory 
{
	PlayerState GetNormalState(Control player);
	PlayerState GetJumpState(Control player);
	PlayerState GetDownState(Control player);
	PlayerState GetEatingState(Control player);
	PlayerState GetFlyingState(Control player);
}
