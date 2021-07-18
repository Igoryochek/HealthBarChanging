using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;

    public int Health { get; private set; }

    private void Start()
    {
        Health = _maxHealth;
    }

    public void ApplyHeal(int heal)
    {
        Health += heal;

        if (Health>=_maxHealth)
        {
            Health = _maxHealth;
        }
    }

    public void ApplyDamage(int damage)
    {
        Health -= damage;

        if (Health <= _minHealth)
        {
            Health = _minHealth;
        }
    }
}
