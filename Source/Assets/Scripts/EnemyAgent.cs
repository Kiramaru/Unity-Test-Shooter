using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAgent : MonoBehaviour
{
    public GameObject MassPoints;
    NavMeshAgent agent;
    public GameObject DeathEnemy;
    public GameObject Player;

    public GameObject MainMenu;
    FunctionUI menu;

    private bool trigger;
    public int count;

    EnemyVision vision;
    void Start()
    {
        count = 0;
        menu = MainMenu.GetComponent<FunctionUI>();  
        Player = GameObject.FindWithTag("Player");
        vision = GetComponent<EnemyVision>();
        agent =  GetComponent<NavMeshAgent>();
        trigger = false;
        agent.destination = MassPoints.transform.GetChild(count).transform.position;//чтоб враг шел к 1 точке
        count++;
    }

    void Update()
    {
        if (agent.remainingDistance < 1 && !vision.flag) //если дистанция между врагом и точкой меньше 1f и враг не видит игрока то
        { 
            if (count >= MassPoints.transform.childCount) count = 0;//если точки кончились то номер точки 0
            agent.destination = MassPoints.transform.GetChild(count).transform.position;//это чтоб враг шел к следующей точке
            count++;//следующий номер точки
        }
        if (vision.flag)//если враг видит игрока
        {
            agent.destination = Player.transform.position;//идет за ним
        }
    }

    void OnCollisionEnter(Collision collision)//если что то касается врага
    {
        switch (collision.transform.tag)
        {
            case "Bullet"://если пуля
                GameObject Bullet = Instantiate(DeathEnemy, transform.position, DeathEnemy.transform.rotation);//создаются эффекты смерти
                Destroy(transform.gameObject);//уничтожается враг
                menu.AddingPoints(100);//добавление очков за убийство врага
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1) menu.EndGameOn();//когда враги закончились выводится сообщение о завершении игры
                break;
            case "Player": menu.HealthBarRemoving(0.2f);//если игрок, то онимается 1/5 жизни
                if(menu.HealthBar.fillAmount < 0.01f) menu.ReastartLevel();
                break;
        }
            
    }
}
