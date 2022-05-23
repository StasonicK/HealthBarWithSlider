using UnityEngine;
using UnityEngine.Events;

public class Person : MonoBehaviour
{
    private float _health;
    private readonly float _maxHealth = 100f;
    private readonly float _minHealth = 0f;

    public UnityAction<float> ChangedHealth;

    private void Start()
    {
        _health = _maxHealth;
        ChangedHealth?.Invoke(_health);
    }

    public void TakeDamage(float damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
        ChangedHealth?.Invoke(_health);
    }

    public void Heal(float heal)
    {
        _health = Mathf.Clamp(_health + heal, _minHealth, _maxHealth);
        ChangedHealth?.Invoke(_health);
    }
}