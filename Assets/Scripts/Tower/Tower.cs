using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    public event UnityAction Lost;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            Lose();
    }

    private void Lose()
    {
        Lost?.Invoke();
    }
}
