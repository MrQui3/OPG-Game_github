using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform position;
    public GameObject movePositionTransform;
    public int randomChild;
    public int wait;
    public Animator animator;



    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        position = GetComponent<Transform>();
        randomChild = Random.Range(0, movePositionTransform.transform.childCount - 1);
        position.position = movePositionTransform.transform.GetChild(Random.Range(0, movePositionTransform.transform.childCount - 1)).position;
        wait = 1500;
        animator.SetFloat("Speed", 2);
    }

    private void Update()
    {

        navMeshAgent.destination = movePositionTransform.transform.GetChild(randomChild).position;

        wait--;
        if (wait == 0)
        {
            randomChild = Random.Range(0, movePositionTransform.transform.childCount - 1);
            wait = 1500;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC_point")
            animator.SetFloat("Speed", 0);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC_point")
            animator.SetFloat("Speed", 2);
    }

}
