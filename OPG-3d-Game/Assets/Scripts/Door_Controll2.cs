using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controll2 : MonoBehaviour
{
    public Animator _doorAnim;

    private void OnTriggerEnter(Collider other)
    {
        _doorAnim.SetBool("isOpening2", true);
        _doorAnim.SetInteger("which", 2);
    }

    private void OnTriggerExit(Collider other)
    {
        _doorAnim.SetBool("isOpening2", false);
        _doorAnim.SetInteger("which", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        _doorAnim.SetBool("isOpening2", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
