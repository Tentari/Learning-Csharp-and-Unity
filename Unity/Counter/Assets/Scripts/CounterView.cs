using System;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Color _defaultColor;

    public event Action MouseClicked;

    private void Start()
    {
        _counterText.text = _counter.StartNumber.ToString("");
        _counterText.color = _defaultColor;
    }

    private void Update()
    {
        CheckInput();
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

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
            MouseClicked?.Invoke();
    }
}