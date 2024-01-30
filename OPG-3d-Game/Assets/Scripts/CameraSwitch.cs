using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
	public Camera camera1st;
	public Camera camera3rd;

	public float Look = 100.0f;

	// Richtungs-Vektor
	private Vector3 LookVector = Vector3.zero;

	// Initialisierung
	void Start()
	{

	}

	// Aufruf viele Male pro Sekunde
	void Update()
	{
		// Auf und ab schauen
		LookVector.x = -Input.GetAxis("Mouse Y");
		camera1st.transform.Rotate(LookVector * Time.deltaTime * Look);
		camera3rd.transform.Rotate(LookVector * Time.deltaTime * Look);

		// 1st oder 3rd?
		if (Input.GetKey(KeyCode.PageUp))
		{
			camera1st.enabled = true;
			camera3rd.enabled = false;
		}
		if (Input.GetKey(KeyCode.PageDown))
		{
			camera1st.enabled = false;
			camera3rd.enabled = true;
		}
	}
}
