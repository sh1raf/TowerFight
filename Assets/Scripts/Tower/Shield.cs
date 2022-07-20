using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Shield : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    [SerializeField] private float _durationOfActivation;
    [SerializeField] private int _cooldownTime;

    private Collider2D _collider2D;

    private Animator _animator;

    public event UnityAction<int, int> HealthChanged;

    public event UnityAction CooldownStart;

    private event UnityAction ActivationEnded;
    public bool _isActive { get; private set; } = false;

    public int CooldownTime => _cooldownTime;
    #region MonoBehaviour
    private void Start()
    {
        _currentHealth = _maxHealth;
        
        _collider2D = GetComponent<Collider2D>();
        _collider2D.enabled = false;

        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ActivationEnded += OnActivationEnd;
    }

    private void OnDisable()
    {
        ActivationEnded -= OnActivationEnd;
    }
    #endregion

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            Shutdown();
    }


    public void Activation()
    {
        if (_isActive == false)
        {
            Debug.Log("in shield activation");
            _collider2D.enabled = true;
            _isActive = true;
            StartCoroutine(ActivationTimer());
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        Debug.Log("Cooldown invoked");
        
        CooldownStart?.Invoke();
        yield return new WaitForSeconds(_cooldownTime);
    }

    private void Shutdown()
    {
        _collider2D.enabled = false;
        _isActive = false;

        _animator.SetTrigger("shutdown");
        _currentHealth = _maxHealth;
    }

    private IEnumerator ActivationTimer()
    {
        var expiredTime = 0f;
        
        while(expiredTime < _durationOfActivation)
        {
            expiredTime += Time.deltaTime;
            yield return null;
        }
        if(_isActive == true)
            _isActive = false;

        ActivationEnded?.Invoke();
    }

    private void OnActivationEnd()
    {
        if (_isActive == false)
        {
            Shutdown();
        }
    }
}
