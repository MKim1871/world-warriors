using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
		
public class InputManager : MonoBehaviour
{
	private PlayerInput playerInput;
	public PlayerInput.OnFootActions onFoot;
	
	public GameObject textMeshObjectRestart;
	public GameObject textMeshObjectMenu;
	
	private TextMeshProUGUI restartTM;
	private TextMeshProUGUI menuTM;
	
	private PlayerMotor motor;
	private PlayerLook look;
	
	//1 is US, 2 is Chinese, 3 is Russian
	static int nationality = 0;
	
	private GameObject assaultRifle;
	private GameObject pistol;
	private GameObject remote;
	private GameObject hammer;
	private GameObject snowball;
	
	private GameObject background;
	
	private GameObject siberiaPortal;
	
	
	void Start()
	{
		// Hide the cursor
        Cursor.visible = false;
		
		assaultRifle = GameObject.Find("Player/Main Camera/Default Guns/Assault Rifle");
		pistol = GameObject.Find("Player/Main Camera/Default Guns/Pistol");
		remote = GameObject.Find("Player/Main Camera/Abilities/Drone Remote");
		hammer = GameObject.Find("Player/Main Camera/Abilities/Hammer");
		snowball = GameObject.Find("Player/Main Camera/Abilities/Snowball Prop");
		background = GameObject.Find("Player/Main Camera/Canvas/Pause Background");
		
		pistol.SetActive(false);
		remote.SetActive(false);
		hammer.SetActive(false);
		snowball.SetActive(false);
		
		background.SetActive(false);
		
		textMeshObjectRestart = GameObject.Find("Player/Main Camera/Canvas/Restart Button");
		textMeshObjectMenu = GameObject.Find("Player/Main Camera/Canvas/Menu Button");
		restartTM = textMeshObjectRestart.GetComponent<TextMeshProUGUI>();
		menuTM = textMeshObjectMenu.GetComponent<TextMeshProUGUI>();
		
		restartTM.text = "";
		menuTM.text = "";
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
			remote.SetActive(false);
			hammer.SetActive(false);
			snowball.SetActive(false);
		}
		if(Input.GetKey(KeyCode.Alpha2))
		{
			assaultRifle.SetActive(false);
			pistol.SetActive(true);
			remote.SetActive(false);
			hammer.SetActive(false);
			snowball.SetActive(false);
		}
		if(Input.GetKey(KeyCode.Alpha3))
		{
			if(nationality != 0)
			{
				assaultRifle.SetActive(false);
				pistol.SetActive(false);
				
				if (nationality == 1)
				{
					remote.SetActive(true);
				}
				if (nationality == 2)
				{
					hammer.SetActive(true);
				}
				if(nationality == 3)
				{
					snowball.SetActive(true);
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1f)
		{
			Time.timeScale = 0f;
			Cursor.visible = true;
			restartTM.text = "Restart";
			menuTM.text = "Menu";
			background.SetActive(true);
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			Cursor.visible = false;
			restartTM.text = "";
			menuTM.text = "";
			background.SetActive(false);
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
		
		//teleportation to new scenes
		if (collision.gameObject.name == "Training Portal")
        {
			SceneManager.LoadScene("Training Level");
        }
		if (collision.gameObject.name == "Portal Back (Training)")
        {
			Debug.Log("hi");
			SceneManager.LoadScene("SampleScene");
        }
		if (collision.gameObject.name == "Egypt Portal")
        {
			SceneManager.LoadScene("Egypt");
        }
		if (collision.gameObject.name == "Portal Back (Egypt)")
		{
			SceneManager.LoadScene("SampleScene");
		}
		if (collision.gameObject.name == "Siberia Portal")
		{
			SceneManager.LoadScene("Siberia");
		}
		if (collision.gameObject.name == "Portal Back (Siberia)")
		{
			SceneManager.LoadScene("Egypt");
		}
		if (collision.gameObject.name == "Victory Portal")
		{
			SceneManager.LoadScene("Victory");
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
