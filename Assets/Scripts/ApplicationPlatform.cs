using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using YG;

public class ApplicationPlatform : MonoBehaviour
{
    public static bool FlagMob;
    public GameObject joystick;
    public GameObject ButtonAttack;

    // ������������� �� ������� GetDataEvent � OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    // ������������ �� ������� GetDataEvent � OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;
    private void Start()
    {
       
        // ��������� ���������� �� ������
        if (YandexGame.SDKEnabled == true)
        {
            // ���� ����������, �� ��������� ��� �����
            GetData();

            // ���� ������ ��� �� �����������, �� ����� �� ����������� � ������ Start,
            // �� �� ���������� ��� ������ ������� GetDataEvent, ����� ��������� �������
        }
       
    }

    public void GetData()
    {
        if (YandexGame.EnvironmentData.deviceType== "mobile")
        {
            ButtonAttack.SetActive(true);
            joystick.SetActive(true);
            FlagMob = true;
            //���������� �� ��
            Debug.Log("Android");
        }
        if (YandexGame.EnvironmentData.deviceType == "desktop")
        {
            ButtonAttack.SetActive(false);
            joystick.SetActive(false);
            FlagMob = false;
            Debug.Log("PC");
        }
    }
}
