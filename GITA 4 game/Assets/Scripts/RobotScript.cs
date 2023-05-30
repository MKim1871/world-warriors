using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject robotPrefab;
	
	private int health = 100;
	private float robotSpeed = 5f;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 distanceFromPlayer = playerPrefab.transform.position - transform.localPosition;
		distanceFromPlayer.y = 0f;
		float angleComparedToPlayer = Vector3.Angle(transform.forward, distanceFromPlayer.normalized);

		if (angleComparedToPlayer < 240f * 0.5f && distanceFromPlayer.magnitude > 1.0f && distanceFromPlayer.magnitude < 10f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(distanceFromPlayer.normalized), 10f * Time.deltaTime);
			
	        transform.Translate(Vector3.forward * robotSpeed * Time.deltaTime);
		}	

    }
	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Pistol Bullet(Clone)")
        {
			health -= 10;
        }
		if (collision.gameObject.name == "Assault Bullet(Clone)")
        {
			health -= 5;
        }
		if (collision.gameObject.name == "Snow Puddle(Clone)")
		{
			robotSpeed = 1f;
		}
		
		if (health < 1)
		{
			Destroy(robotPrefab);
		}
		
	
	}
}
