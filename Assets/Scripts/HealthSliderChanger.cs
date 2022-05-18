using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;

    private float _maxHealth;
    private string PersonDead = "Персонаж умер";
    private string PersonFullHealth = "Персонаж имеет максимум здоровья";
    private Coroutine _job;

    private void Start()
    {
        _maxHealth = _slider.maxValue;
    }

    private void Update()
    {
        _text.text = $"{_slider.value} HP";
        if (_job != null)
        {
            if (_slider.value == _maxHealth)
            {
                _text.text = PersonFullHealth;
                StopCoroutine(_job);
            }
            else if (_slider.value == 0f)
            {
                _text.text = PersonDead;
                StopCoroutine(_job);
            }
        }
    }

    public void MinusTenHP()
    {
        if (_job!=null)
        {
            StopCoroutine(_job);
        }
        
        _job = StartCoroutine(changeHP(_slider.value - 10f));
    }

    public void PlusTenHP()
    {
        if (_job!=null)
        {
            StopCoroutine(_job);
        }

        _job = StartCoroutine(changeHP(_slider.value + 10f));
    }

    private IEnumerator changeHP(float targetHP)
    {
        var waitForOneSeconds = new WaitForSeconds(0.5f);

        while (_slider.value != targetHP)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHP, 1f);
            _text.text = $"{_slider.value} HP";
            yield return waitForOneSeconds;
        }
    }
}