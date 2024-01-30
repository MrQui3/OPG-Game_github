using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	public CharacterController controller;

	public Transform groudCheck;
	public float groudDistance = 0.4f;
	public LayerMask groudMask;
	public bool isGrounded = false;
	public float JumpHeight = 3f;

	public float Speed = 12f;
	public float gravity = -9.81f;
	public GameObject ok_script;
	public GameObject fragen_script;

	Vector3 velocity;
	void Update()
	{
        if (!ok_script.activeSelf && !fragen_script.activeSelf)
        {
			isGrounded = Physics.CheckSphere(groudCheck.position, groudDistance, groudMask);

			if (isGrounded && velocity.y < 0)
			{
				velocity.y = -2f;
			}

			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");

			Vector3 move = transform.right * x + transform.forward * z;

			controller.Move(move * Speed * Time.deltaTime);

			if (Input.GetButtonDown("Jump") && isGrounded)
			{
				velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
			}

			velocity.y += gravity * Time.deltaTime;
			controller.Move(velocity * Time.deltaTime);
		}


	}

	
}
