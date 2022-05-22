using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event UnityAction<float> IsHealed;

    public void TakeDamage()
    {
        IsHealed?.Invoke(-10f);
    }

    public void Heal()
    {
        IsHealed?.Invoke(10f);
    }
}