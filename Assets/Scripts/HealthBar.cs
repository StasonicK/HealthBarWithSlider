using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _health;

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

    private void ChangeHealthBar(string healthText, float health)
    {
        _text.text = healthText;
        _slider.value = health;
        
        Debug.Log($"ChangeHealthBar health {health}");
        Debug.Log($"ChangeHealthBar healthTexth {healthText}");
    }
}