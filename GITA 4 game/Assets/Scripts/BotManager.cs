using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotManager : MonoBehaviour
{
	public GameObject robotPrefab;
	
	private float timeSinceLastSpawn = 0.0f;
	private float botX;
	private float botZ;
	
	GameObject[] robots = new GameObject[12];
	
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < robots.Length; i++)
		{
			Quaternion botRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
			
			if (SceneManager.GetActiveScene().name == "Egypt")
			{
				botX = Random.Range(-30, 30);
				botZ = Random.Range(0, 50);	
				
				GameObject robot = Instantiate(robotPrefab, new Vector3(botX, 0f, botZ), botRotation);
				robots[i] = robot;
			}
			else if (SceneManager.GetActiveScene().name == "Siberia")
			{
				botX = Random.Range(-30, 20);
				botZ = Random.Range(60, 120);

				GameObject robot = Instantiate(robotPrefab, new Vector3(botX, 15f, botZ), botRotation);
				robots[i] = robot;
			}
			
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
					if (SceneManager.GetActiveScene().name == "Egypt")
					{
						botX = Random.Range(-30, 30);
						botZ = Random.Range(0, 50);	
						
						GameObject robot = Instantiate(robotPrefab, new Vector3(botX, 0f, botZ), botRotation);
						robots[i] = robot;
					}
					else if (SceneManager.GetActiveScene().name == "Siberia")
					{
						botX = Random.Range(-30, 20);
						botZ = Random.Range(60, 120);	
						
						GameObject robot = Instantiate(robotPrefab, new Vector3(botX, 15f, botZ), botRotation);
						robots[i] = robot;
					}

				}
			}
			timeSinceLastSpawn = 0f;
		}
    }
}
