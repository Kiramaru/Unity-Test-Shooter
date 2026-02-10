using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunctions : MonoBehaviour
{
    public float MouseSens = 50f;
    public Transform Player;
    public float xRotation = 0f;

    void Start()
    {
        Time.timeScale = 1f;//чтоб все работало при перезапуске сцены, время запускается
        Cursor.lockState = CursorLockMode.Locked;//чтоб курсор не видно было
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;//движение мышки по x
        float MouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;//движение мышки по y

        Player.Rotate(Vector3.up * MouseX);//поворот игрока по x

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//ограничение поворота

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//поворот камеры
    }
}
