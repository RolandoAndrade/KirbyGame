public class BasicPlayerFactory:AbstractPlayerFactory
{
	public ActionsFactory GetActionsFactory()
	{
		return new BasicActionFactory ();
	}

	public StateFactory GetStateFactory()
	{
		return new BasicStateFactory ();
	}
}

