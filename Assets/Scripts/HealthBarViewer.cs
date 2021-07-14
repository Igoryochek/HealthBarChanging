using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarViewer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private int _speed;

    private void OnEnable()
    {
        _player.HealthChanged += StartChangeSlider;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= StartChangeSlider;
    }

    private IEnumerator ChangeHealth(float targetHealth)
    {
        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private void StartChangeSlider(float healthValue)
    {
        StartCoroutine(ChangeHealth(healthValue));
    }
}
