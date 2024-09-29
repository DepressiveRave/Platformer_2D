using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuControl : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel; // Панель вибору рівня
    public GameObject settingsPanel; // Панель налаштувань

    public Vector3 offSreeenPos;

    void Start()
    {

        levelSelectionPanel.transform.localPosition = offSreeenPos;
        settingsPanel.transform.localPosition = offSreeenPos;
        
        
       
    }
    public void ShowLevelSelection()
    {
        mainMenuPanel.SetActive(false);

        levelSelectionPanel.transform.DOLocalMoveY(50, 0.3f).SetEase(Ease.Linear);

    }

    public void CloseLevelSelection()
    {
        mainMenuPanel.SetActive(true);

        levelSelectionPanel.transform.DOLocalMoveY(offSreeenPos.y, 0.3f);
    }

    public void ShowSettingsPanel()
    {
        mainMenuPanel.SetActive(false);

        settingsPanel.transform.DOLocalMoveY(40, 0.3f).SetEase(Ease.Linear);
    }

    public void CloseSettingPanel()
    {
        mainMenuPanel.SetActive(true);

        settingsPanel.transform.DOLocalMoveY(offSreeenPos.y, 0.3f);
    }
}
