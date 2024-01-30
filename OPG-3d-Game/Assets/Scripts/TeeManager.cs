using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TreeManager
{
    public List<Trigger_m> vl;
    public int maxlt;
    public Tree t;
    public string FileName = "Story_l.json";
    private static TreeManager tm;
    public bool building = false;

    private TreeManager()
    {
        maxlt = 25;
        t = new Tree();
        vl = new List<Trigger_m>();
        Debug.Log("Now I'm here!");
    }

    public void TriggerCall(int id)
    {
        t.TriggerEnter(id);
    }
    
    public void ResetTree()
    {
        t.AnfangsKnotenAktivieren();
    }

    public void addTrigger(Trigger_m newT)
    {
        vl.Add(newT);
        Debug.Log("I get it: " + newT.id);
        if (maxlt == vl.Count)
        {
            LoadTree();
        }
    }

    public void LoadTree()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, FileName).Replace("\\", "/").Replace("/","\\");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            StoryData data = JsonUtility.FromJson<StoryData>(json);

            foreach (StoryPart part in data.Story_Parts)
            {
                // Do something with the StoryPart object
                t.Insert(new Node(part.Id, LoadTriggersForNode(part), part.nextNodes, part.Questions));
            }
            building = true;
        }
        else
        {
            Debug.LogError($"File not found: {filePath}");
        }
    }

    public List<Trigger_m> LoadTriggersForNode(StoryPart part)
    {
        List<Trigger_m> triggers = new List<Trigger_m>();

        foreach (int triggerId in part.Trigger)
        {
            Trigger_m trigger = vl[FindtheTrigger(triggerId)];
            if (trigger != null)
            {
                triggers.Add(trigger);
            }
        }
        return triggers;
    }

    public int FindtheTrigger(int id)
    {
        for (int i = 0; i < vl.Count; i++)
        {
            if (vl[i].id == id)
            {
                return i;
            }
        }
        return 99;
    }

    public string GetaktivQuestion()
    {
        return t.GetaktivQuestion();
    }

    public static void TreeManagerStarten()
    {
        tm = new TreeManager();
    }

    public static TreeManager GetTreeManager()
    {
        return tm;
    }  
}

[System.Serializable]
public class StoryPart
{
    public string Questions;
    public int Id;
    public List<int> Trigger;
    public List<int> nextNodes;
}

[System.Serializable]
public class StoryData
{
    public List<StoryPart> Story_Parts;
}
