using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    private float _health;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void ApplyHeal(float heal)
    {
        _health += heal;

        if (_health>=_maxHealth)
        {
            _health = _maxHealth;
        }

        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= _minHealth)
        {
            _health = _minHealth;
        }

        HealthChanged?.Invoke(_health);
    }
}
