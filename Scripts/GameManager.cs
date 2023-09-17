using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager instance;
	public Node gameManagerNode;

	private double _timeBegin;
	private double _timeDelay;

	public override void _Ready()
	{
		instance = this;
		gameManagerNode = this.GetParent<Node>();

		AnimateDancer();
		AnimatePlayers();
	}

	private void AnimateDancer()
	{
		var sceneDancer = GetNode<AnimatedSprite2D>("Dancer/AnimatedSprite2D");
		sceneDancer.Play("Idle");
	}
	private void AnimatePlayers()
	{
		var scenePlayerOne = GetNode<AnimatedSprite2D>("PlayerOne/AnimatedSprite2D");
		scenePlayerOne.Play("Idle");
	}
}
