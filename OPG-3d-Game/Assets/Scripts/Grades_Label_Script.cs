using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grades_Label_Script : MonoBehaviour
{
    public GameObject gradespanel;
    public TextMeshProUGUI grades_label;
    public Trigger_m grades_t;
    public int trigger_id;
    public float grade = 3.0f;

    void Start()
    {
        if (TreeManager.GetTreeManager() == null)
        {
            TreeManager.TreeManagerStarten();
        }
        Debug.Log("Hi, now i'm on, too");
        grades_t = new Trigger_m(trigger_id);
        TreeManager.GetTreeManager().addTrigger(grades_t);
    }

    // Update is called once per frame
    void Update()
    {
        if (grades_t.aktiv)
        {
            gradespanel.SetActive(true);
            grades_label.text = ""+grade;
            
            if (grade >= 5.0)
            {
                TreeManager.GetTreeManager().TriggerCall(grades_t.id);
            }
        }
        else
        {
            gradespanel.SetActive(false);
        }
    }

    public void ChangeGrade(float changegrade)
    {
        if (grade + changegrade >= 0.7)
        {
            grade += changegrade;
            grades_label.text = "" + grade;
        }
    }
}
