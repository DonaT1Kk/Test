using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // ������������ � ����������� ������ �� Y ���������
    public float maxY = 10f;
    public float minY = -5f;
    public GameObject pad1;
    public GameObject pad2;
    // ������� ������
    private Camera mainCamera;
    // ������� ������� - �����, ��� �������� Y � �.; 
    // ����� ������� ��� ������������ ������� ������, �����
    private GameObject player;
    private GameObject paddingOfLeft;
    private GameObject paddingOfRight;
    // ���������� Vector 3  ��� ����������
    private Vector3 posPlayer;
    private Vector3 targetPos;

    private void Awake()
    {
        // ����� ������� � ����� Player. 
        player = GameObject.FindWithTag("Player");
        //���������� �������� ������ � ������� �� ��������
        mainCamera = gameObject.GetComponent<Camera>();
        // ���������� �������� ������ �� ����� PaddingOfLeft, PaddingOfRight
        paddingOfLeft = GameObject.Find("PaddingOfLeft");
        paddingOfRight = GameObject.Find("PaddingOfRight");
    }

    void Update()
    {
        // ������� ������ 
        posPlayer = player.transform.position;
        // �������� �������: ������� ������ �� Y, �������� �� �������
        if (posPlayer.y > -5f && posPlayer.y <= 10f && pad1.transform.position.x >= paddingOfLeft.transform.position.x && pad2.transform.position.x >= paddingOfLeft.transform.position.x && pad2.transform.position.x <= paddingOfRight.transform.position.x && pad1.transform.position.x <= paddingOfRight.transform.position.x)
        {
            // ������ Vector3 � ������� ������ �� X � Y, � �� Z ������ -10f; ����� ��������� ������� � ������
            targetPos = new Vector3(posPlayer.x, posPlayer.y, -10f);
            transform.position = targetPos;
        }
    }
}
