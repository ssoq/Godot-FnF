using Godot;
using System;
using System.IO;
using System.Runtime.CompilerServices;

public partial class GameManager : Node
{
	[ExportSubgroup("Audio")]
	[Export] private AudioStreamPlayer2D music;
	[Export] private AudioStreamPlayer2D singers;
	[Export] private AudioStreamPlayer2D death;
	[Export] private AudioStreamPlayer2D deathMusic;
	[Export] private AudioStreamPlayer2D retrySound;

	[ExportSubgroup("Instancing")]
	public static GameManager instance;
	public Node gameManagerNode;

	[ExportSubgroup("Settings")]
	[Export] public int health = 100;
	[Export] public int healthToAdd = 10;
	[Export] public int healthToMinus = 5;
	[Export] public bool dead = false;

	public override void _Ready()
	{
		instance = this;
		gameManagerNode = this.GetParent<Node>();

		AnimateDancer();
		AnimatePlayers();

		music = GetNode<AudioStreamPlayer2D>("Music");
		singers = GetNode<AudioStreamPlayer2D>("Singers");
		death = GetNode<AudioStreamPlayer2D>("DeathSound");
		deathMusic = GetNode<AudioStreamPlayer2D>("DeathMusic");
		retrySound = GetNode<AudioStreamPlayer2D>("RetryMusic");
	}

	public override void _Process(double delta)
	{
		ClampHealth();
		PlayerDead();
		PlayerDeadLogic();
	}

	private void ClampHealth()
	{
		health = Mathf.Clamp(health, 0, 100);
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

	private void PlayerDead()
	{
		if (health <= 0) dead = true;
	}

	private bool hasPlayedDeath = false;
	private bool hasPlayedRetry = false;
	private void PlayerDeadLogic()
	{
		if (!dead) return;
		music.Stop();
		singers.Stop();

		var retry = Input.IsActionPressed("enter");

		if (!death.Playing && !hasPlayedDeath)
		{
			death.Play();
			deathMusic.Play();
		}

		if (retry && !hasPlayedRetry && dead == true)
		{
			hasPlayedRetry = true;
			deathMusic.Stop();
			retrySound.Play();
		}

		hasPlayedDeath = true;
	}
}
