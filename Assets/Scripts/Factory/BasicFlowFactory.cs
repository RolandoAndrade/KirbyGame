public class BasicFlowFactory:FlowFactory
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

