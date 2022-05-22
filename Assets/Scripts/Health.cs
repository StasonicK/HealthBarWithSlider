using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    public event UnityAction<float> ChangedHealth;

    public void TakeDamage()
    {
        ChangedHealth?.Invoke( _slider.value - 10f);
    }

    public void Heal()
    {
        ChangedHealth?.Invoke( _slider.value + 10f);
    }
}