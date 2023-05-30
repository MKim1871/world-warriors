using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MenuScript : MonoBehaviour
{
	public string helpURL;
	
	public Texture2D hoverCursor;

    void Start()
    {
        

    }

    void OnMouseEnter()
    {
		Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
	
	public void OnMouseDown()
    {
        if (gameObject.name == "Play Button")
        {
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            SceneManager.LoadScene("SampleScene");
        }
        else if (gameObject.name == "Tutorial Button")
        {
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Application.OpenURL(helpURL);
        }
    }
}

