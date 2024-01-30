using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour { 


    public float mouseSensitivty = 150;
    public Transform playerBody;

    private float xRotation = 0f;
    public GameObject ok_script;
    public GameObject fragen_script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ok_script.activeSelf && !fragen_script.activeSelf)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivty * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivty * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
