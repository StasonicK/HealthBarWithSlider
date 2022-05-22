using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private float _maxHealth;
    private Coroutine _job;
    public float CurrentHealth { get; private set; }

    private string PersonDead = "Персонаж умер";
    private string PersonFullHealth = "Персонаж имеет максимум здоровья";

    private void OnEnable()
    {
        _health.IsHealed += ChangeHealth;
    }

    private void OnDisable()
    {
        _health.IsHealed -= ChangeHealth;
    }

    private void Start()
    {
        _maxHealth = _slider.maxValue;
        _text.text = $"{_slider.value} HP";
    }

    private void Update()
    {
        CurrentHealth = _slider.value;
    }

    private void ChangeHealth(float changingValue)
    {
        if (_job != null)
        {
            StopCoroutine(_job);
        }

        _job = StartCoroutine(DoChangeHealth(changingValue + _slider.value));
    }

    private IEnumerator DoChangeHealth(float targetHP)
    {
        var waitForOneSeconds = new WaitForSeconds(0.5f);

        while (_slider.value != targetHP)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHP, 1f);
            _text.text = $"{_slider.value} HP";

            if (_slider.value == _maxHealth)
            {
                _text.text = PersonFullHealth;
                yield return null;
            }
            else if (_slider.value == 0f)
            {
                _text.text = PersonDead;
                yield return null;
            }

            yield return waitForOneSeconds;
        }
    }
}