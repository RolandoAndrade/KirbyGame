using UnityEngine;

public abstract class PlayerState
{
	private Control player;

	private bool isGrounded = false;
	private bool isDownded = false;
	private bool isFlying = false;
	private bool isEating = false;
	private bool isFull = false;

	public PlayerState(Control player)
	{
		this.player = player;
	}

	public abstract PlayerState StateActions();

	public Control GetPlayer()
	{
		return this.player;
	}

	public bool IsFlying()
	{
		return this.isFlying;
	}

	public bool IsGrounded()
	{
		return this.isGrounded;
	}

	public bool IsEating()
	{
		return this.isEating;
	}

	public bool IsDownded()
	{
		return this.isDownded;
	}

	public void SetIsFlying(bool isFlying)
	{
		this.isFlying = isFlying;
	}

	public void SetIsGrounded(bool isGrounded)
	{
		this.isGrounded = isGrounded;
	}

	public void SetIsEating(bool isEating)
	{
		this.isEating = isEating;
	}

	public void SetIsDownded(bool isDownded)
	{
		this.isDownded = isDownded;
	}
}
