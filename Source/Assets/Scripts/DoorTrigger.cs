using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    GameObject Player;
    bool DoorAnimation;


    public bool PlayerCondition;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerCondition && Player.gameObject.GetComponent<PlayerController>().flag)
        {
            DoorAnimation = animator.GetBool("DoorAnimation");
            animator.SetBool("DoorAnimation", !DoorAnimation);
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Player") PlayerCondition = true; 
    }
    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player") PlayerCondition = false;
    }
}
