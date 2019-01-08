using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text Timelabel;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Timelabel.text = Time.realtimeSinceStartup.ToString();
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
