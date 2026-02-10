using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FunctionUI : MonoBehaviour
{
    public GameObject PanelPause;
    public GameObject PanelEndGame;
    public Text Points;
    public Image HealthBar;
    public void GamePauseOFF()//конец паузы игры
    {
        Time.timeScale = 1f;//время запускается
        PanelPause.SetActive(false);//панель скрывается
        Cursor.lockState = CursorLockMode.Locked;//курсора не видно
    }
    public void GamePauseON()//начало паузы игры
    {
        Time.timeScale = 0f;//время останавливается
        PanelPause.SetActive(true);//панель с кнопками становится активной
        Cursor.lockState = CursorLockMode.None;//курсор появляется
    }
    public void Exit()
    {
        Application.Quit();//выход из игры
    }

    public void ReastartLevel()//перезапуск сцены
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGameOn()//финальная надпись игры
    {
        Time.timeScale = 0f;//время останавливается
        PanelEndGame.SetActive(true);//надпись о завершении игры появляется
    }

    public void EndGameOFF()//закрытие финальной надписи игры
    {
        PanelEndGame.SetActive(false);//закрытие финальной панели
        Time.timeScale = 1f;//время запускается
    }

    public void AddingPoints(int PointsCount)//добавление очков игроку
    {
        Points.text = (int.Parse(Points.text) + PointsCount).ToString();
    }

    public void HealthBarAdding(float health)//добавление здоровья
    {
        HealthBar.fillAmount += health;
    }

    public void HealthBarRemoving(float helth)//получение урона
    {
        HealthBar.fillAmount-=helth;
    }
}
