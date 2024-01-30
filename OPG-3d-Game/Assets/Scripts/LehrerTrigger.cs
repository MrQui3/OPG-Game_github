using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LehrerTrigger : MonoBehaviour
{
    public GameObject dialogpanel;
    public GameObject signalpoint;
    public Trigger_m trigger_l;
    public int trigger_id;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (trigger_l.aktiv)
            {
                dialogpanel.SetActive(true);
                TreeManager.GetTreeManager().TriggerCall(trigger_l.id);
                signalpoint.SetActive(false);
            }
        }
        // _doorAnim.SetBool("isOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        
        //dialogpanel.SetActive(false);
        //_doorAnim.SetBool("isOpening", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        trigger_l = new Trigger_m(trigger_id);
        if (TreeManager.GetTreeManager() == null)
        {
            TreeManager.TreeManagerStarten();
        }
        TreeManager.GetTreeManager().addTrigger(trigger_l);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger_l.aktiv)
        {
            signalpoint.SetActive(true);
        }
        else
        {
            signalpoint.SetActive(false);
        }
    }
}
