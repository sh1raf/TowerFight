using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("StartMoving");
    }

    private void Update()
    {
        if (_animator.GetBool("StopMoving") == false)
        {
            transform.Translate(GetCurrentDirection() * _speed * Time.deltaTime);
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("NeedToDestroy"))
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bullet in other collider");
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;

        _animator.SetBool("StopMoving", true);

        if(collision.collider.TryGetComponent<Tower>(out Tower tower))
        {
            tower.TakeDamage(_damage);
        }

        if (collision.collider.TryGetComponent<Shield>(out Shield shield))
        {
            shield.TakeDamage(_damage);
        }
    }

    protected virtual Vector2 GetCurrentDirection()
    {
        return new Vector2(-Mathf.Acos(transform.rotation.z), Mathf.Asin(transform.rotation.z));
    }
}
