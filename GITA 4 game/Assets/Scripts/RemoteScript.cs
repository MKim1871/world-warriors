using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteScript : MonoBehaviour
{
    private bool isHigh;
    private GameObject remote;
    private Transform playerTransform;
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        remote = GameObject.Find("Player/Main Camera/Abilities/Drone Remote");
        playerTransform = GameObject.Find("Player").transform;
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isHigh && remote.activeSelf == true)
            {
                Vector3 currentPosition = cameraTransform.position;
                Vector3 newPosition = currentPosition + new Vector3(0f, 10f, 0f);
                cameraTransform.position = newPosition;
				remote.SetActive(false);
                isHigh = true;
            }
            else if (isHigh)
            {
                Vector3 currentPosition = cameraTransform.position;
                Vector3 newPosition = currentPosition + new Vector3(0f, -10f, 0f);
                cameraTransform.position = newPosition;
				remote.SetActive(true);
                isHigh = false;
            }

            // Reset player's Y position to keep it on the ground
            Vector3 playerPosition = playerTransform.position;
            playerPosition.y = 0f;
            playerTransform.position = playerPosition;
        }
    }
}
