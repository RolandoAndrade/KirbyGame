using System;

public class BasicActionFactory: ActionsFactory
{
	public PlayerAction GetJump(Control player)
	{
		return new Jump (player);
	}

	public PlayerAction GetDown(Control player)
	{
		return new Down (player);
	}

	public PlayerAction GetEat(Control player)
	{
		return new Eat (player);
	}

	public PlayerAction GetFly(Control player)
	{
		return new Fly (player);
	}

	public PlayerAction GetLand(Control player)
	{
		return new Land (player);
	}

	public PlayerAction GetRun(Control player)
	{
		return new Run (player);
	}

	public PlayerAction GetWalk(Control player)
	{
		return new Walk (player);
	}
}

