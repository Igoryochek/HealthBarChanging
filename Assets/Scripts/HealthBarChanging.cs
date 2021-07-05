using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarChanging : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;

    private Coroutine _changingHealth;
    private float _targetHealth;
    private float _damage = 10;
    private float _heal = 10;

    public void Hit()
    {
        _targetHealth = _slider.value - _damage;
        _changingHealth = StartCoroutine(ChangeHealth());

        if (_slider.value <= _slider.minValue)
        {
            _slider.value = _slider.minValue;
        }
    }

    public void Heal()
    {
        _targetHealth = _heal + _slider.value;
        _changingHealth = StartCoroutine(ChangeHealth());

        if (_slider.value >= _slider.maxValue)
        {
            _slider.value = _slider.maxValue;
        }
    }

    private IEnumerator ChangeHealth()
    {
        while (_slider.value != _targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetHealth, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
