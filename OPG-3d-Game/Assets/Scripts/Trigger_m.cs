using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_m 
{
    public int id;
    public bool aktiv = false;

   public Trigger_m(int id)
    {
        this.id = id;
    }
    
    public void Setaktiv(bool on)
    {
        aktiv = on;
    }
   
    public void triggered()
    {
        if (aktiv)
        {
            TreeManager.GetTreeManager().TriggerCall(id);
        }
        else
        {
            return;
        }
    }
}
