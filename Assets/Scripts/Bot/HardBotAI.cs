using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBotAI : Bot
{
    [SerializeField] private TowerMover _targetTower;

    [SerializeField] private Gun _gun;

    [SerializeField] private float _speedOfRotation;

    private void Update()
    {
        Vector2 currentPoint = Physics2D.Raycast(_gun.transform.position, _gun.transform.right).point;
        Vector2 targetPoint = new Vector2(_targetTower.transform.position.x, (_targetTower.transform.position.y - _targetTower.WayPoints[_targetTower.CurrentPoint].position.y) / 5);

        //FindAnglesInTriangle(_gun.transform.position, currentPoint, targetPoint);

        if (currentPoint.y < targetPoint.y)
            _gun.transform.Rotate(0, 0, _speedOfRotation * Time.deltaTime);

        else if (currentPoint.y > targetPoint.y)
            _gun.transform.Rotate(0,0, -_speedOfRotation * Time.deltaTime);
    }
}
