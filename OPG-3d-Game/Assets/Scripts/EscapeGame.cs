using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeGame : MonoBehaviour
{
    public GameObject camera1st;
    public GameObject cameratop;
    public GameObject main_menu;
    public GameObject ende_screen;
    public GameObject HUP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            camera1st.SetActive(false);
            cameratop.SetActive(true);
            main_menu.SetActive(true);
            HUP.SetActive(false);
            ende_screen.SetActive(false);
        }
    }
}
