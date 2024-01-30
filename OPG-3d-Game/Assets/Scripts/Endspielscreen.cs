using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Endspielscreen : MonoBehaviour
{

    public Trigger_m triggerende;
    public int trigger_id = 24;
    public Grades_Label_Script gs;
    public TextMeshProUGUI gradeLabel;
    public GameObject endscreen1;
    // Start is called before the first frame update
    void Start()
    {
        if (TreeManager.GetTreeManager() == null)
        {
            TreeManager.TreeManagerStarten();
        }
        Debug.Log("Hi, now i'm on, too");
        triggerende = new Trigger_m(trigger_id);
        TreeManager.GetTreeManager().addTrigger(triggerende);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerende.aktiv)
        {
            gradeLabel.text = gs.grade+"";
        }
        else
        {
            endscreen1.SetActive(false);
        }
    }
}
