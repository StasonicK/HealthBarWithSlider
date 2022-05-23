using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Person _person;
    [SerializeField] private float _timeStep = 0.5f;

    private const string PersonDead = "Персонаж умер";
    private const string PersonFullHealth = "Персонаж имеет максимум здоровья";

    private Coroutine _job;

    public event UnityAction<string, float> ChangedHealth;

    public void TakeDamage()
    {
        ChangeHealthBar(_person.CurrentHealth - 10f);
    }

    public void Heal()
    {
        ChangeHealthBar(_person.CurrentHealth + 10f);
    }

    private void ChangeHealthBar(float targetHP)
    {
        if (_job != null)
        {
            StopCoroutine(_job);
        }

        _job = StartCoroutine(DoChangeHealth(targetHP));
    }

    private IEnumerator DoChangeHealth(float targetHP)
    {
        string healthText;
        var waitForOneSeconds = new WaitForSeconds(_timeStep);

        bool isNormalValue = true;

        while (_person.CurrentHealth != targetHP)
        {
            // if (!isNormalValue)
            // {
            //     yield return waitForOneSeconds;
            //     break;
            // }
            
            float health = Mathf.MoveTowards(_person.CurrentHealth, targetHP, 1f);
            
            Debug.Log($"DoChangeHealth health {health}");

            if (health == _person.MaxHealth)
            {
                healthText = PersonFullHealth;
                ChangedHealth?.Invoke(healthText, health);
                isNormalValue = false;
                yield return waitForOneSeconds;
            }
            else if (health == 0f)
            {
                healthText = PersonDead;
                ChangedHealth?.Invoke(healthText, health);
                isNormalValue = false;
                yield return waitForOneSeconds;
            }
            else
            {
                healthText = $"{health} HP";
                ChangedHealth?.Invoke(healthText, health);
                yield return waitForOneSeconds;
            }
        }
    }
}