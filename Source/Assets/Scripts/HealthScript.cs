using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public GameObject Player;

    public bool PlayerCondition;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    
    }

    void Update()
    {
        if (Player.gameObject.GetComponent<PlayerController>().flag && PlayerCondition) transform.parent.gameObject.GetComponent<DestroyHealth>().Destroy();//если игрок находится в зоне триггера и нажал на кнопку действия то запускается действия в скрипте DestroyHealth
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player") PlayerCondition = true;//когда игрок входит в триггер, то может нажимать на кнопку действия
    }
    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player") PlayerCondition = false;//если вышел то взаимодействия с аптечкой не будет
    }
}
