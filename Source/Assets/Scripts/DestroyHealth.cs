using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyHealth : MonoBehaviour
{
    public GameObject MainMenu;
    FunctionUI menu;

    private void Start()
    {
        menu = MainMenu.GetComponent<FunctionUI>();
    }

    public void Destroy()
    {
        if (menu.HealthBar.fillAmount!=1f)//если игрок касается триггера, нажата кнопка действия и его здоровье меньше максимального, то
        {
            menu.HealthBarAdding(0.2f);//добавляется 1/5 от полоски здоровья
            Destroy(transform.GetChild(0).gameObject);//удаляется вложенный триггер
            Destroy(transform.gameObject);//удаляется аптечка
        }
    }
}
