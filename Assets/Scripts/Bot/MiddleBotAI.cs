using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBotAI : Bot
{

    [SerializeField] private TowerMover _targetTower;

    [SerializeField] private Gun _gun;

    [SerializeField] private float _speedOfRotation;

    private void Update()
    {
        Vector2 currentPoint = Physics2D.Raycast(_gun.transform.position, _gun.transform.right).point;
        Vector2 targetPoint = new Vector2(_targetTower.transform.position.x, (_targetTower.transform.position.y - _targetTower.WayPoints[_targetTower.CurrentPoint].position.y) / 2);

        //FindAnglesInTriangle(_gun.transform.position, currentPoint, targetPoint);

        if (currentPoint.y < targetPoint.y)
            _gun.Rotate(_speedOfRotation);

        else if (currentPoint.y > targetPoint.y)
            _gun.Rotate(-_speedOfRotation);
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(_gun.transform.position, _gun.transform.right, Color.red);
    }

    private float[] FindAnglesInTriangle(Vector2 A, Vector2 B, Vector2 C)
    {
        float a = Vector2.Distance(B, C);
        float b = Vector2.Distance(A, C);
        float c = Vector2.Distance(B, C);

        float cosa = (a * a + c * c - b * b) / 2 * a * c;
        float cosb = (a * a + b * b - c * c) / 2 * a * b;
        float cosc = (b * b + c * c - a * a) / 2 * b * c;

        return new float[] { Mathf.Acos(cosa), Mathf.Acos(cosb), Mathf.Acos(cosc)};
    }
}
