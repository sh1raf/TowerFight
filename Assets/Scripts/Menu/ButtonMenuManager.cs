using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenuManager : MonoBehaviour
{

    public void OnExitButtonClick()
    {
        Application.Quit();

    }

    [SerializeField] private GameObject _settigns;
    public void OnSettingsButtonClick()
    {
        _settigns.SetActive(true);
    }

    public void OnPlayVSPlayerButtonClick()
    {

    }

    [SerializeField] private GameObject _botSettings;
    [SerializeField] private Bot _easyBot;
    [SerializeField] private Bot _middleBot;
    [SerializeField] private Bot _hardBot;

    public void OnPlayVSBotButtonClick()
    {
        _botSettings.SetActive(true);
    }

    public void OnEasyButtonClick()
    {
        SceneConnector.BotPrefab = _easyBot;
    }

    public void OnMiddleButtonClick()
    {
        SceneConnector.BotPrefab = _middleBot;
    }

    public void OnHardButtonClikc()
    {
        SceneConnector.BotPrefab = _hardBot;
    }
}
