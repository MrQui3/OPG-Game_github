using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stundenplan_controll : MonoBehaviour
{
    public GameObject buttontoTimetabel;
    public GameObject timetabel;
    public GameObject dialogtabel;
    public GameObject short_information_tabel;
    public Trigger_m stundenplanacess_trigger;
    public int trigger_id;
    private int showed = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (TreeManager.GetTreeManager() == null)
        {
            TreeManager.TreeManagerStarten();
        }
        stundenplanacess_trigger = new Trigger_m(trigger_id);
        TreeManager.GetTreeManager().addTrigger(stundenplanacess_trigger);
    }

    // Update is called once per frame
    void Update()
    {
        if (stundenplanacess_trigger.aktiv)
        {
            buttontoTimetabel.SetActive(true);
        }
    }
    
    public void TimetabelButtonClickt()
    {
        if (showed == 0)
        {
            timetabel.SetActive(true);
            dialogtabel.SetActive(false);
            short_information_tabel.SetActive(false);
            showed = 1;
        }
        else
        {
            timetabel.SetActive(false);
            dialogtabel.SetActive(true);
            short_information_tabel.SetActive(true);
            showed = 0;
        }
    }
}
