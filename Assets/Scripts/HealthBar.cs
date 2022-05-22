using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthText += ChangeHealth;
    }

    private void OnDisable()
    {
        _health.HealthText -= ChangeHealth;
    }

    private void Start()
    {
        _text.text = $"{_health.CurrentHealth} HP";
    }

    private void ChangeHealth(string healthText)
    {
        _text.text = healthText;
    }
}