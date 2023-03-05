using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Максимальная и минимальная высота по Y персонажа
    public float maxY = 10f;
    public float minY = -5f;
    public GameObject pad1;
    public GameObject pad2;
    // Атрибут камера
    private Camera mainCamera;
    // Игровые объекты - игрок, для проверки Y и т.; 
    // Также объекты для максимальной границы вправо, влево
    private GameObject player;
    private GameObject paddingOfLeft;
    private GameObject paddingOfRight;
    // Переменные Vector 3  для вычислений
    private Vector3 posPlayer;
    private Vector3 targetPos;

    private void Awake()
    {
        // Поиск объекта с тегом Player. 
        player = GameObject.FindWithTag("Player");
        //Нахождение атрибута камера у объекта со скриптом
        mainCamera = gameObject.GetComponent<Camera>();
        // Нахождение объектов границ по имени PaddingOfLeft, PaddingOfRight
        paddingOfLeft = GameObject.Find("PaddingOfLeft");
        paddingOfRight = GameObject.Find("PaddingOfRight");
    }

    void Update()
    {
        // Позиция игрока 
        posPlayer = player.transform.position;
        // Проверка условий: позиция игрока по Y, проверка по границе
        if (posPlayer.y > -5f && posPlayer.y <= 10f && pad1.transform.position.x >= paddingOfLeft.transform.position.x && pad2.transform.position.x >= paddingOfLeft.transform.position.x && pad2.transform.position.x <= paddingOfRight.transform.position.x && pad1.transform.position.x <= paddingOfRight.transform.position.x)
        {
            // Задаем Vector3 с позиции игрока по X и Y, а по Z всегда -10f; После применяем позицию к камере
            targetPos = new Vector3(posPlayer.x, posPlayer.y, -10f);
            transform.position = targetPos;
        }
    }
}
