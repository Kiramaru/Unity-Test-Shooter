using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    static CharacterController characterController;
    private Vector3 velocity;

    public GameObject MainMenu;
    FunctionUI menu;

    public GameObject BulletPrefab;
    public GameObject SpavnPoint;

    public float Power;
    private Camera MainCamera;

    public bool flag;
    
    float FastSpeed = 10f;
    float UsualSpeed = 5f;
    float JumpHeight = 3f;

    float gravity = -9.8f;

    public Transform GroundCheckTransform;
    public float GroundDistance = 0.2f;
    public LayerMask GroundMask;
    public bool isGround;

    void Start()
    {
        menu = MainMenu.GetComponent<FunctionUI>();
        Time.timeScale = 1f;
        MainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        flag = false;
    }

    void Update()
    {
 
        float x = Input.GetAxis("Horizontal"); //нажатие кнопок
        float z = Input.GetAxis("Vertical");

        float run = Input.GetAxis("Run");
        float jump = Input.GetAxis("Jump");

        Vector3 move = transform.right * x + transform.forward * z;//вектор направлени€ движени€

        if (run>0) characterController.Move(move * FastSpeed * Time.deltaTime);//если нажат бег то перемещаетс€ с более быстрой скоростью
        else characterController.Move(move * UsualSpeed * Time.deltaTime);//если не нажат то медленее
        velocity.y += gravity * Time.deltaTime;//скорость по высоте увеличивваетс€ на гравитацию
        characterController.Move(velocity * Time.deltaTime);//скорость по высоте примен€етс€ к персонажу

        isGround = Physics.CheckSphere(GroundCheckTransform.position, GroundDistance, GroundMask);//проверка на землю под персонажем
        if (isGround && velocity.y < 0) velocity.y = -2f;
        if(jump>0 && isGround)//если нажат прыжок и персонаж на земле
        {
            velocity.y = (float)Math.Sqrt(JumpHeight * -2f * gravity);// персонаж прыгнет
            isGround = false;//тк на земле его не будет то false
        }

        if (Input.GetButtonDown("Menu"))//если нажата кнопка вызова меню
        {
            if (menu.PanelEndGame.activeSelf) menu.EndGameOFF();//если панель с надписью о конце игры активна, то закрываетс€
            else
            {
                switch(menu.PanelPause.activeSelf)//меню активно или нет
                {
                    case false: menu.GamePauseON();//если нет, то открыть окно с меню
                        break;
                    case true: menu.GamePauseOFF();//если да, то закрыть
                        break;
                }
            }
        }

        if (Input.GetButtonDown("Interaction")) flag = true;//значение флага считывают функции и аптечках и двер€х
        else flag = false;

        if (Input.GetButtonDown("Fire"))//если нажата кнопка стрельбы
        {
            Shooting();//функци€ стрельбы
        }
    }

    void Shooting()
    {
        Ray ray = MainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//середина экрана
        RaycastHit hit;

        Vector3 TargetPoint;
        if(Physics.Raycast(ray, out hit)) TargetPoint = hit.point;//если луч во что то попадает, то пускаетс€ на это рассто€ние
        else TargetPoint = ray.GetPoint(100);//если нет то луч пускаетс€ на 100 единиц
        Vector3 ShootVector = TargetPoint - SpavnPoint.transform.position; //конечна€ позици€ пули - начальна€
        
        GameObject Bullet = Instantiate(BulletPrefab, SpavnPoint.transform.position, Quaternion.identity);//пул€ по€вл€етс€ в стартовой позиции
        Bullet.transform.forward = ShootVector.normalized;//поворот пули в направлении движени€
        Bullet.GetComponent<Rigidbody>().AddForce(ShootVector.normalized * 100, ForceMode.Impulse);//полет пули
    }

}
