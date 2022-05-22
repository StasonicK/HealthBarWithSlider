using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _health;
    [SerializeField] private float _timeStep = 0.5f;

    private const string PersonDead = "Персонаж умер";
    private const string PersonFullHealth = "Персонаж имеет максимум здоровья";
    
    private Coroutine _job;

    private void OnEnable()
    {
        _health.ChangedHealth += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _health.ChangedHealth -= ChangeHealthBar;
    }

    private void Start()
    {
        _text.text = $"{_slider.value} HP";
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
        var waitForOneSeconds = new WaitForSeconds(_timeStep);

        while (_slider.value != targetHP)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHP, 1f);

            if (_slider.value == _slider.maxValue)
            {
                _text.text = PersonFullHealth;
            }
            else if (_slider.value == _slider.minValue)
            {
                _text.text = PersonDead;
            }
            else
            {
                _text.text = $"{_slider.value} HP";
            }

            yield return waitForOneSeconds;
        }
    }
}