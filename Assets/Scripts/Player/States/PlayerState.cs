using UnityEngine;

public abstract class PlayerState
{
	protected Control player;
	protected FlowFactory flowFactory;

	public PlayerState(Control player)
	{
		this.player = player;
		this.player = flowFactory;
	}

	public PlayerState Execute()
	{
		PlayerState ps = this.ExecuteStateActions ();
		this.SetAnimations ();
		return ps;
	}
		
	public abstract PlayerState ExecuteStateActions();

	public abstract void SetAnimations();

	public Control GetPlayer()
	{
		return this.player;
	}
}