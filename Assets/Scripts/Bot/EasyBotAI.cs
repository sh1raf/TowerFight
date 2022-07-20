using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBotAI : Bot
{
    [SerializeField] private Gun _gun;

    private List<int> _listOfRandomNumbers = new List<int>();

    private void Start()
    {
        StartCoroutine(Rotate(GetRandomOfTwo(-1, 1), Random.Range(3, 5)));
    }


    private IEnumerator Rotate(float yDirection, float rotateDuration)
    {
        var scaleOfRotation = 0f;
        var expiredTime = 0f;

        while(expiredTime < rotateDuration)
        {
            expiredTime += Time.deltaTime;

            scaleOfRotation = expiredTime / rotateDuration;
            _gun.Rotate(scaleOfRotation * yDirection);

            yield return null;
        }

        StartCoroutine(Rotate(GetRandomOfTwo(-1, 1), Random.Range(3, 5)));
    }

    private int GetRandomOfTwo(int firstNumber, int secondNumber)
    {
        _listOfRandomNumbers.Add(firstNumber);
        _listOfRandomNumbers.Add(0);
        _listOfRandomNumbers.Add(secondNumber);

        int random = Random.Range(_listOfRandomNumbers[0], _listOfRandomNumbers[_listOfRandomNumbers.Count - 1]);
        _listOfRandomNumbers.Remove(random);

        if (_listOfRandomNumbers.Count == 0)
        {
            Debug.Log("Count == 0");
            _listOfRandomNumbers.Add(firstNumber);
            _listOfRandomNumbers.Add(0);
            _listOfRandomNumbers.Add(secondNumber);
        }

        return random;
    }
}
