using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public static int game_state = 0;
    public GameObject camera1st;
    public GameObject main_menu;
    public GameObject HUP;
    public GameObject Main_Menu;
    public GameObject FAQ_slied;
    public DayNightCircl timergame;
    public Transform Playerobject;
    public Grades_Label_Script gradelabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonPressed()
    {
        camera1st.SetActive(true);
        main_menu.SetActive(false);
        game_state = 1;
        HUP.SetActive(true);
        Main_Menu.SetActive(false);
        if (TreeManager.GetTreeManager().building)
        {
            TreeManager.GetTreeManager().ResetTree();
            timergame.time = 27000;
            Playerobject.position = new Vector3(472.4f, 6.71f, 542.8f);
            gradelabel.grade = 2.5f;
        }
    }
    public void OptionButtonPressed()
    {

    }
    public void ExitButtonPressed()
    {
        QuitGame();
    }
    private void QuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
    public void FAQButtonClicked1()
    {
        Main_Menu.SetActive(false);
        FAQ_slied.SetActive(true);
    }
    public void FAQButtonClicked2()
    {
        Main_Menu.SetActive(true);
        FAQ_slied.SetActive(false);
    }
}
