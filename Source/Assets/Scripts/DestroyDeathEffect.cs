using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeathEffect : MonoBehaviour
{

    private float timelife = 3;//врем€ жизни эффекта смерти
    void Update()
    {
        timelife -= Time.deltaTime;//таймер, после истечени€€ которого эффект смерти уничтожаетс€
        if (timelife < 0)
        {
            Destroy(transform.gameObject);
        }
    }

}
