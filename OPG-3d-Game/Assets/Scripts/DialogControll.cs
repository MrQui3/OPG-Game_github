using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogControll : MonoBehaviour
{
    public GameObject dialogpanel;
    public GameObject gradespanel;
    public GameObject decisionpanel;
    public GameObject Informationpanel;
    public GameObject EndpielScreen;
    public GameObject HUP;
    public DialogControll information_script;
    public Decision_script decisionscript;
    public Endspielscreen endspiel;
    public Trigger_m okdialog;
    public TextMeshProUGUI questionLabel;
    public int trigger_id;
    public Grades_Label_Script gls;

    // Start is called before the first frame update
    void Start()
    {
        if (TreeManager.GetTreeManager() == null)
        {
            TreeManager.TreeManagerStarten();
        }
        Debug.Log("Hi, now i'm on, too");
        okdialog = new Trigger_m(trigger_id);
        TreeManager.GetTreeManager().addTrigger(okdialog);
        EndpielScreen.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (okdialog.aktiv)
        {
            dialogpanel.SetActive(true);
            questionLabel.text = TreeManager.GetTreeManager().GetaktivQuestion();
        }
        else
        {
            if (endspiel.triggerende.aktiv)
            {
                EndpielScreen.SetActive(true);
                HUP.SetActive(false);

            }
            dialogpanel.SetActive(false);
        }
    }

    public void OkButtonClicked()
    {
        if (okdialog.aktiv)
        {
            TreeManager.GetTreeManager().TriggerCall(okdialog.id);
            if (information_script.okdialog.aktiv)
            {
                Informationpanel.SetActive(true);
            }
            if (decisionscript.decisiontrigger1.aktiv)
            {
                decisionpanel.SetActive(true);
            }
            
        }
        if (okdialog.aktiv)
        {
            if (gls.grades_t.aktiv)
            {
                gradespanel.SetActive(true);
            }
            dialogpanel.SetActive(true);
        }
        else
        {
            dialogpanel.SetActive(false);
        }
    }
}
