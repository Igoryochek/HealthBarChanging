using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    private float _health;

    public void Heal(float heal)
    {
        _health += heal;

        if (_health>=_maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void Hit(float damage)
    {
        _health += damage;

        if (_health <= _minHealth)
        {
            _health = _minHealth;
        }
    }
}
