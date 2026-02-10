using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float radius;
    public bool flag = false;

    [Range(0,360)]public float angle;

    private void Update()
    {
        flag = false;//изначально игрока не видно поэтому false
        Collider[] targets = Physics.OverlapSphere(
            transform.position, radius ); //от позиции врага рисуется круг с заданым радиусом и в массив записывает все колайдеры, которые в него попали
        foreach(Collider target  in targets)
        {
            if (target.CompareTag("Player") && CheckingObstacle(target)) // если в радиус попал игрок и между врагом и игроком нет стены или других предметов, то
            {
                float SignedAngle = Vector3.Angle(transform.forward, target.transform.position - transform.position);//вычисляется угол между перпендикеуляром выпущенным из середины передней части 
                //врага и игроком
                if(Mathf.Abs(SignedAngle)<angle/2)//проверяется меньше заданного угла или нет
                flag = true;//если меньше значит враг видит игрока
                break;
            }
        }
    }

    public bool CheckingObstacle(Collider collider)//проверка на наличие предметов посторонних между игроком и врагом
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, collider.transform.position - transform.position);//направление луча в сторону игрока
        Physics.Raycast(ray, out hit);
        if (hit.collider!=null && hit.collider.gameObject.tag == "Player") return true;//если постороннего предмета нету то true
        return false;
    }


}