using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Person _person;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _delay;
    [SerializeField] private float _changingValue = 1f;

    private Coroutine _coroutine;
    private float _normalizingValue = 100f;

    private void OnEnable()
    {
        _person.ChangedHealth += OnChangedHealth;
    }

    private void OnDisable()
    {
        _person.ChangedHealth -= OnChangedHealth;
    }

    private void OnChangedHealth(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeHealth(value));
    }

    private IEnumerator ChangeHealth(float value)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);
        float normalisedValue = value / _normalizingValue;

        while (normalisedValue != _slider.value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, normalisedValue, _changingValue * Time.deltaTime);

            yield return waitForSeconds;
        }
    }
}