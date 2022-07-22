using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{

    [SerializeField] private Image _botSettingsPanel;

    [SerializeField] private Image _settignsPanel;


    public void OnPlayVSBotButtonClick()
    {
        _botSettingsPanel.gameObject.SetActive(true);
    }
    public void OnPlayVSPlayerButtonClick()
    {

    }

    public void OnSettingsButtonClick()
    {
        _settignsPanel.gameObject.SetActive(true);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
