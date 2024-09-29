using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons; // ����� ������ ��� ����

    private void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // �� ������������� ������� ����� 1 �����

        // ����������, �� ��� ������
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > unlockedLevel)
            {
                levelButtons[i].interactable = false; // ������� ���, �� �� �� ������
            }
        }
    }

    // ����� ��� ������������ ����
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex); // ����������� ����� ���������� ����
    }
}
