using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleScript : MonoBehaviour
{
	private float remainTime = 0.0f;
	public GameObject puddlePrefab;
	
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
			Debug.Log(remainTime);
			remainTime += Time.deltaTime;
			
			if (remainTime > 3.0f)
			{
				Destroy(puddlePrefab);
			}
        }
	}
}
