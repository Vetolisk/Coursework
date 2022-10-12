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

    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;
    private void Start()
    {
       
        // Проверяем запустился ли плагин
        if (YandexGame.SDKEnabled == true)
        {
            // Если запустился, то запускаем Ваш метод
            GetData();

            // Если плагин еще не прогрузился, то метод не запуститься в методе Start,
            // но он запустится при вызове события GetDataEvent, после прогрузки плагина
        }
       
    }

    public void GetData()
    {
        if (YandexGame.EnvironmentData.deviceType== "mobile")
        {
            ButtonAttack.SetActive(true);
            joystick.SetActive(true);
            FlagMob = true;
            //Устройство не пк
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
