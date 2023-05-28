using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
	public GameObject snowballPrefab;
	
	private float snowballSpeed = 10.0f;
	private float reloadTime = 0.0f;
	private bool isReloading;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
			if (Input.GetButtonDown("Fire1") && !isReloading) {
				// Code to throw
				Quaternion playerRotation = transform.rotation;
				Quaternion snowballRotation = Quaternion.Euler(playerRotation.eulerAngles.x, playerRotation.eulerAngles.y, playerRotation.eulerAngles.z + 90f);
				
				//Generates and throws ball
				GameObject snowball = Instantiate(snowballPrefab, transform.position + new Vector3(0, 0.2f, 0), snowballRotation);
				snowball.GetComponent<Rigidbody>().velocity = transform.forward * snowballSpeed;
				
				//cooldown
				isReloading = true;
			}
			
		if (isReloading)
		{
			reloadTime += Time.deltaTime;
			
			if (reloadTime > 5.0f)
			{
				reloadTime = 0;
				isReloading = false;
			}
		}
    }
}
