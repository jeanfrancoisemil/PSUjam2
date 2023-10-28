using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, Player.IMainActions {

	public CharacterController2D controller;
	public Animator animator;

	private Player player;

	private float moveActions;
	private bool jumpInput;
	private bool downInput;
	
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;
	private static readonly int Grounded = Animator.StringToHash("Grounded");

	//bool dashAxis = false;

	private void Start()
	{
		if (player == null)
		{
			player = new Player();
			player.main.SetCallbacks(this);
		}

		player.main.Enable();

	}

	// Update is called once per frame
	void Update () {

		horizontalMove = moveActions * runSpeed;


		if (jumpInput)
		{
			jump = true;
		}

		if (downInput)
		{
			if(jump == false) GoDown();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			dash = true;
		}
		

	}

	public void OnFall()
	{
		animator.SetBool(Grounded, false);
	}

	public void OnLanding()
	{
		animator.SetBool(Grounded, true);
	}

	public void GoDown()
	{
		var position = this.transform.position;
		position.Set(position.x, position.y-10, position.z);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}
	



	public void OnMove(InputAction.CallbackContext context)
	{
		moveActions = context.ReadValue<float>();
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		jumpInput = context.performed;
	}

	public void OnDown(InputAction.CallbackContext context)
	{
		downInput = context.performed;
	}	
	



}
