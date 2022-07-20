using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _bar;

    private void Start()
    {
        _bar.value = 1;
    }

    private void OnValueChanged(int value, int maxValue)
    {
        _bar.value = value / maxValue;
    }
}
