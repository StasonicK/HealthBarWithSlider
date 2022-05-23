using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public float MaxHealth => _slider.maxValue;
    public float CurrentHealth => _slider.value;
}