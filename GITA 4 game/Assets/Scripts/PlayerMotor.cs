using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
	public GameObject textMeshObject;
	
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool isGrounded;
	private bool isSprinting;
	private float speed = 5f;
	private float gravity = -20.0f;
	private float jumpHeight = 3f;
	private int healthAmount = 100;
	
	private TextMeshProUGUI healthAmountTM;
	
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
		
		//Set-up text values
		textMeshObject = GameObject.Find("Player/Main Camera/Canvas/Health Amount");
		healthAmountTM = textMeshObject.GetComponent<TextMeshProUGUI>();
		
		healthAmountTM.text = healthAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
		healthAmountTM.text = healthAmount.ToString();
		
        isGrounded = controller.isGrounded;
    }
	
	//Receives inputs from InputManager.cs and applies them to controller
	public void ProcessMove(Vector2 input)
	{
		Vector3 moveDirection = Vector3.zero;
		//allows left or right movement, is z and not y because y is up
		moveDirection.x = input.x;
		moveDirection.z = input.y;

		if (Input.GetKey(KeyCode.LeftShift))
    	{
        	moveDirection *= 2f; // Double the movement speed when sprinting
    	}

		controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
		playerVelocity.y += gravity * Time.deltaTime;
		
		if(isGrounded && playerVelocity.y < 0)
		{
			playerVelocity.y = -2f;
		}
		
		controller.Move(playerVelocity * Time.deltaTime);
	}
	
	public void Jump()
	{
		if(isGrounded)
		{
			playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Melee Robot(Clone)")
        {
			healthAmount -= 1;
			Debug.Log(healthAmount);
        }
		//teleportation to new scenes
		if (collision.gameObject.name == "Training Portal")
        {
			SceneManager.LoadScene("Training Level");
        }
		if (collision.gameObject.name == "Egypt Portal")
        {
			SceneManager.LoadScene("Egypt");
        }
	}
}
