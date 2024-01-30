using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngineScript : MonoBehaviour
{
    public bool Pause;
    public int time;
    public GameObject NPCs;
    public GameObject movePositionTransform;
    public int randomChild;
    // Start is called before the first frame update
    void Start()
    {
        Pause = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time == 3000)
        {
            Pause = true;
            for (int i = 0; i < NPCs.transform.childCount; i++)
            {
                while (true)
                {
                    randomChild = Random.Range(0, movePositionTransform.transform.childCount - 1);
                    if (movePositionTransform.transform.GetChild(randomChild).GetComponent<Script_for_points>().erlaubt_in_der_pause_zu_sein)
                        break;
                }
                NPCs.transform.GetChild(i).GetComponent<UnityEngine.AI.NavMeshAgent>().destination = movePositionTransform.transform.GetChild(randomChild).position;
            }
            time = 0;
        }
        if (!Pause)
            time++;




    }
}
