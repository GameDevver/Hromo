using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public float timer;
    public bool ispuse;
    public bool guipuse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = timer;
        if(Input.GetKeyDown(KeyCode.P) && ispuse == false)
        {
            ispuse = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && ispuse == true)
        {
            ispuse = false;
        }
        if(ispuse==true)
        {
            timer = 0;
            guipuse = true;
        }
        else if(ispuse == false)
        {
            timer = 1f;
            guipuse = false;
        }
	}

    public void OnGUI()
    {
       if(guipuse==true)
        {
            Cursor.visible = true;
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) -150f, 150f,50f), "Продолжить"))
            {
                ispuse = false;
                timer = 0;
                Cursor.visible = false;
            }
        }
    }
}
