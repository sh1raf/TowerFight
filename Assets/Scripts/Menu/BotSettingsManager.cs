using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BotSettingsManager : MonoBehaviour
{
    [SerializeField] private Button _easyBotButton;
    [SerializeField] private Button _middleBotButton;
    [SerializeField] private Button _hardBotButton;

    public event UnityAction BotDifficultyLevelSelected;

    private List<Button> _buttons = new();

    private void Start()
    {
        _buttons.Add(_easyBotButton);
        _buttons.Add(_middleBotButton);
        _buttons.Add(_hardBotButton);
    }

    public void OnEasyButtonClick()
    {
        SelectBotLevel(_easyBotButton);
    }

    public void OnMiddleButtonClick()
    {
        SelectBotLevel(_middleBotButton);
    }

    public void OnHardButtonClick()
    {
        SelectBotLevel(_hardBotButton);
    }

    private void SelectBotLevel(Button currentButtonOfDifficulty)
    {
        _buttons.Remove(currentButtonOfDifficulty);

        foreach(var button in _buttons)
            button.enabled = false;

        if (currentButtonOfDifficulty.GetComponent<Bot>())
            SceneConnector.BotPrefab = currentButtonOfDifficulty.GetComponent<Bot>();
        else
            Debug.Log(currentButtonOfDifficulty.name + "need Bot Component");

        BotDifficultyLevelSelected?.Invoke();
    }
}
