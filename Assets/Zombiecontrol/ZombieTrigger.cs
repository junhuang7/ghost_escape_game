using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    private Animator animator; 
    // private bool playerIsNear = false;


    private void OnTriggerEnter(Collider other)
    {

        animator.SetBool("PlayerIsNear", true); 
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("PlayerIsNear", false); 
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

    // public bool IsPlayerNear()
    // {
    //     return playerIsNear;
    // }
    }    

}
