using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
	public GameObject robotPrefab;
	
	private float timeSinceLastSpawn = 0.0f;
	private float botX;
	private float botZ;
	
	
	GameObject[] robots = new GameObject[10];
	
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < robots.Length; i++)
		{
			Quaternion botRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
			botX = Random.Range(-30, 30);
			botZ = Random.Range(0, 50);
			
			GameObject robot = Instantiate(robotPrefab, new Vector3(botX, 0f, botZ), botRotation);

			// Add robot to array
			robots[i] = robot;
		}
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
		
		if (timeSinceLastSpawn > 10.0f)
		{
			for (int i = 0; i < robots.Length; i++)
			{
				Quaternion botRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
				if (robots[i] == null)
				{
					botX = Random.Range(-30, 30);
					botZ = Random.Range(0, 50);
					
					GameObject robot = Instantiate(robotPrefab, new Vector3(botX, 0f, botZ), botRotation);

					// Add robot to array
					robots[i] = robot;
				}
			}
			timeSinceLastSpawn = 0f;
		}
    }
}
