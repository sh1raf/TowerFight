using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShots;

    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private Transform _barrel;

    [SerializeField] private float _rotationBlockValue;

    [SerializeField] private float _speedOfRotation;

    private float _expiredTime;

    private void Update()
    {
        _expiredTime += Time.deltaTime;
        if (_expiredTime >= _timeBetweenShots)
        {
            Shoot();
            _expiredTime = 0;
        }
    }

    public void Shoot()
    {
        Instantiate(_bulletPrefab, _barrel.position, transform.rotation);
    }

    public void Rotate(float rotationValue)
    {

        if (transform.rotation.z <= _rotationBlockValue / 100 && transform.rotation.z >= -_rotationBlockValue / 100)
        {
            //Debug.Log(-_rotationBlockValue + "<" + transform.position.z + "<" + _rotationBlockValue);
            transform.Rotate(0, 0, -rotationValue * Time.deltaTime * _speedOfRotation);
        }
        else if (transform.rotation.z <= _rotationBlockValue / 100 && -rotationValue > 0 || 
            transform.rotation.z >= -_rotationBlockValue / 100 && -rotationValue < 0)
            transform.Rotate(0, 0, -rotationValue * Time.deltaTime * _speedOfRotation);
    }
}
