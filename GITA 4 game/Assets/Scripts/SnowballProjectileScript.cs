using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballProjectileScript : MonoBehaviour
{
	public GameObject puddlePrefab;
	public GameObject snowball;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnCollisionEnter(Collision collision)
	{
		//collide with floor
		if (collision.gameObject.name == "Floor")
        {
			Quaternion puddleRotation = Quaternion.Euler(0f, 0f, 0f);
			GameObject puddle = Instantiate(puddlePrefab, transform.position + new Vector3(0, -0.23f, 0), puddleRotation);
			Destroy(snowball);
			Destroy(puddle, 5f);
        }
	}
}
