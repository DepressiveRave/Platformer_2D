using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public int FruitsQuantity;
    private bool Loger = true;
    void Update()
    {
       if (FruitsQuantity == 0) LevelComplite();
    }

    void LevelComplite()
    {
        if (Loger)
        {
            Debug.Log("LevelComplite");
            Loger = false;
            PlayerPrefs.SetInt("UnlockedLevel", 2);
        }

    }
}
