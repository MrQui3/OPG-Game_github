using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controll1 : MonoBehaviour
{
    public Animator _doorAnim;

    private void OnTriggerEnter(Collider other)
    {
        _doorAnim.SetBool("isOpening", true);
        _doorAnim.SetInteger("which", 1);
    }

    private void OnTriggerExit(Collider other)
    {
        _doorAnim.SetBool("isOpening", false);
        _doorAnim.SetInteger("which", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        _doorAnim.SetBool("isOpening", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
