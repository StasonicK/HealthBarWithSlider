using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private HealthChanger _healthChanger;

    private float _maxHealth;
    private string PersonDead = "Персонаж умер";
    private string PersonFullHealth = "Персонаж имеет максимум здоровья";
    private Coroutine _job;

    private void OnEnable()
    {
        _healthChanger.IsPlusTenHP += ChangeHealth;
    }

    private void OnDisable()
    {
        _healthChanger.IsPlusTenHP -= ChangeHealth;
    }

    private void Start()
    {
        _maxHealth = _slider.maxValue;
        _text.text = $"{_slider.value} HP";
    }

    private void ChangeHealth(bool isPlusTenHP)
    {
        if (_job != null)
        {
            StopCoroutine(_job);
        }

        float targetHP = isPlusTenHP ? _slider.value + 10f : _slider.value - 10f;

        _job = StartCoroutine(DoChangeHealth(targetHP));
    }

    private IEnumerator DoChangeHealth(float targetHP)
    {
        
            var waitForOneSeconds = new WaitForSeconds(0.5f);

            while (_slider.value != targetHP)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, targetHP, 1f);
                
                if (_slider.value == _maxHealth)
                {
                    yield return null;
                }
                else if (_slider.value == 0f)
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