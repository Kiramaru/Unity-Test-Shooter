using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyVision))]
public class ManagerEditor : Editor
{
    private void OnSceneGUI()//это для того, чтоб можно было посмотреть как работает видимость у врагов (чтоб посмотреть в проекте юнити нажмите на врага)
    {
        EnemyVision vision = (EnemyVision)target;
        Color c = Color.blue;
        Handles.color = new Color(c.r, c.g, c.b, 0.3f);//чтоб полупрозрачный был
        Handles.DrawSolidArc(vision.transform.position, vision.transform.up, Quaternion.AngleAxis(-vision.angle/2f, vision.transform.up)*vision.transform.forward, vision.angle, vision.radius);//рисование треугольника с выбранным углом, в пределах которого враг может видеть предметы
        Handles.color = Color.blue;//назначение цвета области
        vision.radius = Handles.ScaleValueHandle(vision.radius, vision.transform.position + vision.transform.forward * vision.radius, vision.transform.rotation, 3, Handles.SphereHandleCap, 1);//окружность, в которой будет треугольник с заданным углом
    }
}
