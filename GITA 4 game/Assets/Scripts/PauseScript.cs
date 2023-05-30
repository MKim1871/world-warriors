using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class PauseScript : MonoBehaviour
{
	public GameObject background;
	public Texture2D hoverCursor;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnMouseEnter()
    {
		if (background.activeSelf)
		{
			Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
		}
    }

    void OnMouseExit()
    {
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
	
	public void OnMouseDown()
    {
		if (background.activeSelf)
		{
			if (gameObject.name == "Menu Button")
			{
				Time.timeScale = 1f;
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
				SceneManager.LoadScene("Main Menu");
			}
			else if (gameObject.name == "Restart Button")
			{
				Time.timeScale = 1f;
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}	
		}
	
    }
}
