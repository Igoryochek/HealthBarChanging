using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarViewer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private int _speed;

    private Coroutine _changingHealthBarValue;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private IEnumerator ChangeHealthBarValue(int targethealth)
    {
        while (_slider.value != targethealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targethealth, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnHealthChanged(int health)
    {
        if (_changingHealthBarValue != null)
        {
            StopCoroutine(_changingHealthBarValue);
        }

        _changingHealthBarValue = StartCoroutine(ChangeHealthBarValue(health));
    }
}
