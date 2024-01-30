using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    Node root;
    Node n_aktiv;
    List<Node> nv;

    public Tree()
    {
        root = null;
        n_aktiv = null;
        nv = new List<Node>();
    }

    // Der erste Knoten muss einzeln als Wurzel eingefügt werden.
    public void InsertRoot(Node n)
    {
        root = n;
        n_aktiv = root;
        n_aktiv.AktivTrigger(true);
    }

    //Methode noch nicht ganz fertig, da nr der Index des Knoten ist an den der vektor drangehängt wird
    //Einfügen der neuen Knoten public
    public void Insert(Node nat)
    {
        if (root == null)
        {
            InsertRoot(nat);
        }
        nv.Add(nat);
    }

    // Methode wird von TreeManagement aufgerufen, wenn ein Trigger getriggert wird.
    public void TriggerEnter(int nid)
    {
        Debug.Log("Trigger entered: "+ nid);
        // Es gibt einen neuen aktiven Knoten.
        n_aktiv.AktivTrigger(false);
        // ID für br herausfinden.
       //onsole.WriteLine("I got it: " + n_aktiv.br[n_aktiv.PostionNodeFind(id)]);
        Node k = GetNode(n_aktiv.br[n_aktiv.PostionNodeFind(nid)]);
        Debug.Log("New Node: " + k.nr);
        n_aktiv = k;
        if (n_aktiv != null)
        {
            n_aktiv.AktivTrigger(true);
        }
    }

    public void AnfangsKnotenAktivieren()
    {
        n_aktiv.AktivTrigger(false);
        n_aktiv = root;
        if (n_aktiv != null)
        {
            n_aktiv.AktivTrigger(true);
        }
    }

    public string GetaktivQuestion()
    {
        return n_aktiv.GetQuestion();
    }

    // Sucht den passenden Knoten in dem Vektor.
    public Node GetNode(int index)
    {
        for (int i = 0; i < nv.Count; i++)
        {
            if (nv[i].nr == index)
            {
                return nv[i];
            }
        }
        return null;
    }

}
