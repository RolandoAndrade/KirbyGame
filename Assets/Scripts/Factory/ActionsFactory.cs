public interface ActionsFactory
{
	PlayerAction GetJump(Control player);
	PlayerAction GetDown(Control player);
	PlayerAction GetEat(Control player);
	PlayerAction GetFly(Control player);
	PlayerAction GetLand(Control player);
	PlayerAction GetRun(Control player);
	PlayerAction GetWalk(Control player);
}