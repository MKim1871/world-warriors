using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
		
public class InputManager : MonoBehaviour
{
	private PlayerInput playerInput;
	public PlayerInput.OnFootActions onFoot;
	
	private PlayerMotor motor;
	private PlayerLook look;
	
	//1 is US, 2 is Chinese, 3 is Russian
	static int nationality = 0;
	
	private GameObject assaultRifle;
	private GameObject pistol;
	private GameObject snowball;
	
	void Start()
	{
		assaultRifle = GameObject.Find("Player/Main Camera/Default Guns/Assault Rifle");
		pistol = GameObject.Find("Player/Main Camera/Default Guns/Pistol");
		snowball = GameObject.Find("Player/Main Camera/Abilities/Snowball Prop");
		
		pistol.SetActive(false);
		snowball.SetActive(false);
	}
    // Start is called before the first frame update
    void Awake()
    {
	
        playerInput = new PlayerInput();
		onFoot = playerInput.OnFoot;
		motor = GetComponent<PlayerMotor>();
		look = GetComponent<PlayerLook>();
		onFoot.Jump.performed += ctx => motor.Jump();
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.Alpha1))
		{
			assaultRifle.SetActive(true);
			pistol.SetActive(false);
			snowball.SetActive(false);
		}
		if(Input.GetKey(KeyCode.Alpha2))
		{
			assaultRifle.SetActive(false);
			pistol.SetActive(true);
			snowball.SetActive(false);
		}
		if(Input.GetKey(KeyCode.Alpha3))
		{
			if(nationality != 0)
			{
				assaultRifle.SetActive(false);
				pistol.SetActive(false);

				if(nationality == 3)
				{
					snowball.SetActive(true);
				}
			}
		}
	
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		//switch nationality
		if (collision.gameObject.name == "US Equipper")
        {
			nationality = 1;
        }
		if (collision.gameObject.name == "Chinese Equipper")
        {
			nationality = 2;
        }
		if (collision.gameObject.name == "Russian Equipper")
        {
			nationality = 3;
        }
	}
	
    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the player motor to move using the value from the movement action
		motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
	
	void LateUpdate()
	{
		look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
	}
	private void OnEnable()
	{
		onFoot.Enable();
	}
	private void OnDisable()
	{
		onFoot.Disable();
	}
}
