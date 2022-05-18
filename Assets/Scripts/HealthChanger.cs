using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthChanger : MonoBehaviour
{
    public event UnityAction<bool> IsPlusTenHP;

    public void MinusTenHP()
    {
        IsPlusTenHP?.Invoke(false);
    }

    public void PlusTenHP()
    {
        IsPlusTenHP?.Invoke(true);
    }
}