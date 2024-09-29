using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons; // Масив кнопок для рівнів

    private void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // За замовчуванням відкрито тільки 1 рівень

        // Перевіряємо, які рівні відкриті
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > unlockedLevel)
            {
                levelButtons[i].interactable = false; // Блокуємо рівні, які ще не відкриті
            }
        }
    }

    // Метод для завантаження рівня
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex); // Завантажуємо сцену відповідного рівня
    }
}
