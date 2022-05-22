using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _timeStep = 0.5f;

    private const string  PersonDead = "Персонаж умер";
    private const string  PersonFullHealth = "Персонаж имеет максимум здоровья";
    public event UnityAction<string> HealthText;
    private Coroutine _job;
    public float CurrentHealth => _slider.value;

    public void TakeDamage()
    {
        if (_job != null)
        {
            StopCoroutine(_job);
        }

        _job = StartCoroutine(ChangeHealth(_slider.value - 10f));
    }

    public void Heal()
    {
        if (_job != null)
        {
            StopCoroutine(_job);
        }

        _job = StartCoroutine(ChangeHealth(_slider.value + 10f));
    }

    private IEnumerator ChangeHealth(float targetHP)
    {
        string healthText;
        var waitForOneSeconds = new WaitForSeconds(_timeStep);
        
        while (_slider.value != targetHP)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHP, 1f);
            healthText = $"{_slider.value} HP";

            if (_slider.value == _slider.maxValue)
            {
                HealthText?.Invoke(PersonFullHealth);
            }
            else if (_slider.value == _slider.minValue)
            {
                HealthText?.Invoke(PersonDead);
            }
            else
            {
                HealthText?.Invoke(healthText);
            }

            yield return waitForOneSeconds;
        }

        // if (_slider.value == _slider.maxValue)
        // {
        //     HealthText?.Invoke(PersonFullHealth);
        //     yield return waitForOneSeconds;
        // }
        // else if (_slider.value == _slider.minValue)
        // {
        //     HealthText?.Invoke(PersonDead);
        //     yield return waitForOneSeconds;
        // }
    }
}