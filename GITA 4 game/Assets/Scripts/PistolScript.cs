using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PistolScript : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject textMeshObject;
	public Camera camera;
	
	private float bulletSpeed = 50.0f;
	private float recoilAmount = 0.1f;
	private float reloadTime = 0.0f;
	private int bulletAmount = 12;
	private bool isScoped;
	private bool isReloading;
	private Vector3 startingPosition;
	
	private TextMeshProUGUI bulletAmountTM;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
		
		textMeshObject = GameObject.Find("Player/Main Camera/Canvas/Bullet Amount");
		bulletAmountTM = textMeshObject.GetComponent<TextMeshProUGUI>();
		
		bulletAmountTM.text = bulletAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {		
		bulletAmountTM.text = bulletAmount.ToString();
		if (Input.GetButton("Fire2") && !isScoped) 
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, startingPosition + new Vector3(-1f, 0.2f, -0.2f), Time.deltaTime * 10f);
			
			if (transform.localPosition == startingPosition + new Vector3(-0.6f, -0f, -0.6f))
			{
				isScoped = true;
			}
		}
		
		if (!isScoped)
		{
			//Restores to original position
			transform.localPosition = Vector3.Lerp(transform.localPosition, startingPosition, Time.deltaTime * 10f);
			
			isScoped = false;
		}
		
		if (bulletAmount > 0 && !isReloading)
		{
			if (Input.GetButtonDown("Fire1")) {
				// Code to shoot
				Quaternion playerRotation = transform.rotation;
				Quaternion bulletRotation = Quaternion.Euler(playerRotation.eulerAngles.x, playerRotation.eulerAngles.y, playerRotation.eulerAngles.z + 90f);
				
				//Generates and shoots bullet
				GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.2f, 0), bulletRotation);
				bullet.GetComponent<Rigidbody>().velocity = transform.right * bulletSpeed;
				
				//Code for recoil
				transform.localPosition += new Vector3(0, 0, -recoilAmount);
				
				//Code for bullet decreasing
				bulletAmount--;
				bulletAmountTM.text = bulletAmount.ToString();
			}	
		}
		
		//Reload code
		if (Input.GetKeyDown(KeyCode.R) && !isReloading) 
		{			
			isReloading = true;
		}
		
		if (isReloading)
		{
			reloadTime += Time.deltaTime;
			bulletAmountTM.text = "Reloading...";
			
			if (reloadTime > 2.0f)
			{
				bulletAmount = 12;
				bulletAmountTM.text = bulletAmount.ToString();
				reloadTime = 0;
				isReloading = false;
			}
		}
        
		
    }
}