using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private Text _text;
    [SerializeField] private int _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;

    private Coroutine _changingHealth;
    private float _targetHealth;

    public void Hit()
    {
        _targetHealth = _slider.value - _damage;
        _changingHealth = StartCoroutine(ChangeHealth());
        _player.Hit(_damage);
        _text.text =_targetHealth.ToString();

        if (_slider.value <= _slider.minValue)
        {
            _slider.value = _slider.minValue;
        }
    }

    public void Heal()
    {
        _targetHealth = _heal + _slider.value;
        _changingHealth = StartCoroutine(ChangeHealth());
        _player.Heal(_heal);
        _text.text = _targetHealth.ToString();

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
