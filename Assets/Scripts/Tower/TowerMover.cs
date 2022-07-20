using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerMover : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    public int CurrentPoint { get; private set; } = 0;

    public Transform[] WayPoints => _wayPoints;

    private void Update()
    {
        Transform target = _wayPoints[CurrentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, Random.Range(_minSpeed, _maxSpeed) * Time.deltaTime);

        if(transform.position == target.position)
        {
            CurrentPoint++;

            if (CurrentPoint >= _wayPoints.Length)
                CurrentPoint = 0;
        }
    }
}
