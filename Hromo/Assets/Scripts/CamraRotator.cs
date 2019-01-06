using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraRotator : MonoBehaviour {
    Quaternion originRotation;
    float angleHorizontal;
    float angleVertical;
    float mouseSens = 5;
    float stopFactor = 4;
    // Use this for initialization
    void Start () {
        originRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        angleHorizontal += Input.GetAxis("Mouse X") * mouseSens;
        angleVertical += Input.GetAxis("Mouse Y") * mouseSens;

        angleVertical = Mathf.Clamp(angleVertical, -60, 60);

        Quaternion rotationY = Quaternion.AngleAxis(angleHorizontal, Vector3.up);

        transform.rotation = originRotation * rotationY;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.right / stopFactor;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.right / stopFactor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + transform.forward / stopFactor;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position - transform.forward / stopFactor;
        }

    }
}
