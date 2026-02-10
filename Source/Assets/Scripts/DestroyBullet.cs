using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Trigger") Destroy(transform.gameObject);//уничтожение пули сразу после столкновения со всем, кроме предметов с тегом Trigger
    }
}
