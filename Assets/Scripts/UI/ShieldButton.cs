using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ShieldButton : MonoBehaviour
{
    [SerializeField] private Image _blockground;

    [SerializeField] private TMP_Text _timer;
    [SerializeField] private TMP_Text _errorText;

    [SerializeField] private Shield _shield;

    private bool _isCooldownTimerActive;


    #region MonoBehaviour
    private void Start()
    {
        Debug.Log("ShielButton Start started");
        _errorText.SetText("");
        _blockground.gameObject.SetActive(false);
        _timer.SetText("");
    }

    private void OnEnable()
    {
        _shield.CooldownStart += OnCooldownStarted;
    }

    private void OnDisable()
    {
        _shield.CooldownStart -= OnCooldownStarted;
    }
    #endregion
    public void OnShieldButtonClick()
    {
        Debug.Log("Button Active");
        if (_shield._isActive == false)
        {
            Debug.Log("Shield isn't active");
            _shield.Activation();
        }
        else
        {
            Debug.Log("Error");
            StartCoroutine(ErrorTextActivation());
        }
    }


    private void OnCooldownStarted()
    {
        if (_isCooldownTimerActive == false)
        {
            StartCoroutine(CooldownTimer());
            _blockground.gameObject.SetActive(true);
        }
    }

    private IEnumerator CooldownTimer()
    {
        _isCooldownTimerActive = true;

        for(int i = _shield.CooldownTime; i >= 0; i--)
        {
            _timer.SetText(i.ToString());
            yield return new WaitForSeconds(1);
        }
        _timer.SetText("");
        _blockground.gameObject.SetActive(false);

        _isCooldownTimerActive = false;
    }
    private IEnumerator ErrorTextActivation()
    {

        _errorText.SetText("Error");

        yield return new WaitForSeconds(1);

        _errorText.SetText("");
    }
}
