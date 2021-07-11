using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBarViewer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    private HealthBarViewer _healthBarViewer;
    private float _health;

    private void Start()
    {
        _healthBarViewer = GetComponent<HealthBarViewer>();
        _health = _maxHealth;
    }

    public void ApplyHeal(float heal)
    {
        _health += heal;

        if (_health>=_maxHealth)
        {
            _health = _maxHealth;
        }

        StartCoroutine(_healthBarViewer.ChangeHealth(_health));
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= _minHealth)
        {
            _health = _minHealth;
        }

        StartCoroutine(_healthBarViewer.ChangeHealth(_health));
    }
}
