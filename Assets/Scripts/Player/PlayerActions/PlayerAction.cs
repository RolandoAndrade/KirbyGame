public abstract class PlayerAction 
{
	private Control player;
	public PlayerAction(Control player)
	{
		this.player = player;
	}

	public abstract bool Execute();

	public Control GetPlayer()
	{
		return this.player;
	}
}
