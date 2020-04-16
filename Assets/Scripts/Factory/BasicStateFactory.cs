public class BasicStateFactory : StateFactory 
{
	public PlayerState GetNormalState(Control player)
	{
		return new NormalState (player);
	}

	public PlayerState GetJumpState(Control player)
	{
		return new JumpState (player);
	}
		
	public PlayerState GetDownState(Control player)
	{
		return new DownState (player);
	}

	public PlayerState GetEatState(Control player)
	{
		return new EatingState (player);
	}

	public PlayerState GetLandState(Control player)
	{
		return new Land (player);
	}

	public PlayerState GetFlyingState(Control player)
	{
		return new FlyingState (player);
	}
}
