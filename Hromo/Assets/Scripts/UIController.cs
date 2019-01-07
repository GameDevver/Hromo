using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text Scorelabel;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Scorelabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        Debug.Log("Open settings");
    }
    
    public void OnOpenDown()
    {
        Debug.Log("Settings down");
    }
}
