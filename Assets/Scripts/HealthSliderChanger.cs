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

    void Start()
    {
        _maxHealth = _slider.maxValue;
    }

    public void MinusTenHP()
    {
        if (_slider.value <= 10.0f)
        {
            _text.text = PersonDead;
            _slider.value = 0f;
        }
        else
        {
            _slider.value -= 10f;
            _text.text = $"{_slider.value} HP";
        }
    }

    public void PlusTenHP()
    {
        if (_slider.value >= _maxHealth - 10f)
        {
            _text.text = PersonFullHealth;
            _slider.value = _maxHealth;
        }
        else
        {
            _slider.value += 10f;
            _text.text = $"{_slider.value} HP";
        }
    }
}