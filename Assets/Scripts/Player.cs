using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;

    private int _health;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void ApplyHeal(int heal)
    {
        _health += heal;

        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }

        HealthChanged.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= _minHealth)
        {
            _health = _minHealth;
        }

        HealthChanged.Invoke(_health);
    }
}
