using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    [SerializeField] private Joystick _joystick;

    private void Update()
    {
        _gun.Rotate(_joystick.Vertical);
    }

}
