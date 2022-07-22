using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMeneger : MonoBehaviour
{
    [SerializeField] private BotSettingsManager _botSettingsManager;

    private void Start()
    {
    }

    private void OnEnable()
    {
        _botSettingsManager.BotDifficultyLevelSelected += StartGame;
    }

    private void OnDisable()
    {
        _botSettingsManager.BotDifficultyLevelSelected -= StartGame;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
