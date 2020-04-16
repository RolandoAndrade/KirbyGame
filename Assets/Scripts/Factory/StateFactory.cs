public interface StateFactory 
{
	PlayerState GetNormalState(Control player);
	PlayerState GetJumpState(Control player);
	PlayerState GetDownState(Control player);
	PlayerState GetEatState(Control player);
	PlayerState GetLandState(Control player);
	PlayerState GetFlyingState(Control player);
}
