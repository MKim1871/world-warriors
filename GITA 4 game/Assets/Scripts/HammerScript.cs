using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public GameObject wallPrefab;
	
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
				// Code to make
				Quaternion playerRotation = transform.rotation;
				Quaternion wallRotation = Quaternion.Euler(0f, playerRotation.eulerAngles.y, 0f);
				
				GameObject wall = Instantiate(wallPrefab, transform.position + new Vector3(0, 0f, 3f), wallRotation);
				
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
