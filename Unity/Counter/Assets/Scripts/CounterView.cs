using System;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Color _defaultColor;

    private void Start()
    {
        _counterText.text = _counter.StartNumber.ToString("");
        _counterText.color = _defaultColor;
    }

    private void OnEnable()
    {
        _counter.NumberChanged += UpdateCounterText;
    }

    private void OnDisable()
    {
        _counter.NumberChanged -= UpdateCounterText;
    }

    private void UpdateCounterText(float newNumber)
    {
        _counterText.text = newNumber.ToString("F2");
    }
}