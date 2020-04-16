using System;

public class BasicActionFactory
{
	public PlayerAction GetJump(Control player)
	{
		return new Jump (player);
	}

	PlayerAction GetDown(Control player)
	{
		return new Down (player);
	}

	PlayerAction GetEat(Control player)
	{
		return new Eat (player);
	}

	PlayerAction GetFly(Control player)
	{
		return new Fly (player);
	}

	PlayerAction GetLand(Control player)
	{
		return new Land (player);
	}

	PlayerAction GetRun(Control player)
	{
		return new Run (player);
	}

	PlayerAction GetWalk(Control player)
	{
		return new Walk (player);
	}
}

