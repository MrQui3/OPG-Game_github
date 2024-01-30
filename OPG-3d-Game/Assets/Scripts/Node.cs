using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Node 
{
    public int nr;
    public List<Trigger_m> at;
    public List<int> br;
    string question;

    public Node(int neu_nr, List<Trigger_m> n_at, List<int> n_br, string n_question)
    {
        nr = neu_nr;
        at = n_at;
        br = n_br;
        question = n_question;
        Debug.Log("Test of this class");
    }

    public void AktivTrigger(bool on)
    {
        if (at.Count != 0)
        {
            for (int i = 0; i < at.Count; i++)
            {
                at[i].Setaktiv(on);
            }
        }
    }
    public string GetQuestion()
    {
        return question;
    }
    public int PostionNodeFind(int id)
    {
        if (at.Count != 0)
        {
            for (int i = 0; i < at.Count; i++)
            {
                if (at[i].id == id)
                {
                    return i;
                }
            }
        }

        return 99;
    }

    public int KnotennummerzumTrigger(int t_id)
    {
        int pos_t = 0;
        for (int i = 0; i < at.Count; i++)
        {
            if (at[i].id == t_id)
            {
                pos_t = i;
            }
        }
        return br[pos_t];
    }
}
