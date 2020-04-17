using UnityEngine;

public abstract class PlayerState
{
	protected Control player;
	protected FlowFactory flowFactory;

	public PlayerState(Control player, FlowFactory flowFactory)
	{
		this.player = player;
		this.flowFactory = flowFactory;
	}

	public PlayerState Execute()
	{
		PlayerState ps = this.ExecuteStateActions ();
		this.SetAnimations ();
		return ps;
	}
		
	public abstract PlayerState ExecuteStateActions();

	public abstract void SetAnimations();
}