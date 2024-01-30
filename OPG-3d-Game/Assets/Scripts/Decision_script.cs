using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class Decision_script : MonoBehaviour
{
    public GameObject dialogpanel;
    public GameObject decisionpanel;
    public Trigger_m decisiontrigger1;
    public Trigger_m decisiontrigger2;
    public Trigger_m trigger_noteSchlechter;
    public Trigger_m trigger_notebesser;
    public TextMeshProUGUI questionLabel;
    public DialogControll dialog_script;
    public int trigger_id1;
    public int trigger_id2;
    public int trigger_id_schlechter;
    public int trigger_id_besser;
    public Grades_Label_Script grades;
    // Start is called before the first frame update
    void Start()
    {
    if (TreeManager.GetTreeManager() == null)
    {
        TreeManager.TreeManagerStarten();
    }
        Debug.Log("Hi, now i'm on, too");
        decisiontrigger1 = new Trigger_m(trigger_id1);
        TreeManager.GetTreeManager().addTrigger(decisiontrigger1);
        decisiontrigger2 = new Trigger_m(trigger_id2);
        TreeManager.GetTreeManager().addTrigger(decisiontrigger2);
        trigger_noteSchlechter = new Trigger_m(trigger_id_schlechter);
        TreeManager.GetTreeManager().addTrigger(trigger_noteSchlechter);
        trigger_notebesser = new Trigger_m(trigger_id_besser);
        TreeManager.GetTreeManager().addTrigger(trigger_notebesser);
    }

    // Update is called once per frame
    void Update()
    {
        if (decisiontrigger1.aktiv && decisiontrigger2.aktiv)
        {
            decisionpanel.SetActive(true);
            questionLabel.text = TreeManager.GetTreeManager().GetaktivQuestion();
        }
        else
        {
            decisionpanel.SetActive(false);
        }
    }

    public void ClickedYes()
    {
    if (decisiontrigger1.aktiv)
    {
        TreeManager.GetTreeManager().TriggerCall(decisiontrigger1.id);
        if (dialog_script.okdialog.aktiv)
        {
            dialogpanel.SetActive(true);
        }
    }
    if (decisiontrigger1.aktiv)
    {
        decisionpanel.SetActive(true);
    }
    if (trigger_noteSchlechter.aktiv)
        {
            grades.ChangeGrade(0.2f);
        }
    else if (trigger_notebesser.aktiv)
        {
            grades.ChangeGrade(-0.2f);
        }
    }

    public void ClickedNo()
    {
    if (decisiontrigger2.aktiv)
    {
        TreeManager.GetTreeManager().TriggerCall(decisiontrigger2.id);
        if (dialog_script.okdialog.aktiv)
        {
            dialogpanel.SetActive(true);
        }
    }
    if (decisiontrigger2.aktiv)
    {
        decisionpanel.SetActive(true);
    }
        if (trigger_noteSchlechter.aktiv)
        {
            grades.ChangeGrade(0.2f);
        }
        else if (trigger_notebesser.aktiv)
        {
            grades.ChangeGrade(-0.2f);
        }
    }
}
