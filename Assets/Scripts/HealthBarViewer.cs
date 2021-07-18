using UnityEngine;
using UnityEngine.UI;

public class HealthBarViewer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private int _speed;

    private void Update()
    {
        if (_slider.value!=_player.Health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value,_player.Health, _speed * Time.deltaTime);
        }
    }
}
