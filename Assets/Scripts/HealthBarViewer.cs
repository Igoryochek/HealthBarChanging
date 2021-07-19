using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarViewer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private int _speed;

    private Coroutine changingHealthBarValue;

    private void OnEnable()
    {
        _player.HealthChanged += OnChangeHealthBar;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnChangeHealthBar;
    }

    private IEnumerator ChangeHealthBarValue(int targethealth)
    {
        while (_slider.value != targethealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targethealth, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnChangeHealthBar(int health)
    {
        if (changingHealthBarValue != null)
        {
            StopCoroutine(changingHealthBarValue);
        }

        changingHealthBarValue = StartCoroutine(ChangeHealthBarValue(health));
    }
}
