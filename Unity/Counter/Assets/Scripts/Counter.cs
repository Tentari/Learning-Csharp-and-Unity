using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countdownTime;
    [SerializeField] private float _startNumber;
    [SerializeField] private float _numberToAdd;
    [SerializeField] private CounterView _counterView;

    private float _currentNumber;
    private bool _isRun;
    private bool _isCoroutineRun;

    public float StartNumber => _startNumber;

    public event Action<float> NumberChanged;

    private void Start()
    {
        _currentNumber = _startNumber;
    }

    private void Update()
    {
        TryAddNumber();
    }

    private void OnEnable()
    {
        _counterView.MouseClicked += UpdateState;
    }

    private void OnDisable()
    {
        _counterView.MouseClicked -= UpdateState;
    }

    private void TryAddNumber()
    {
        if (_isRun && !_isCoroutineRun)
        {
            StartCoroutine(DelayedAddNumber());
        }
    }

    private void UpdateState()
    {
        _isRun = !_isRun;
    }

    private IEnumerator DelayedAddNumber()
    {
        _isCoroutineRun = true;

        yield return new WaitForSeconds(_countdownTime);

        _currentNumber += _numberToAdd;
        NumberChanged?.Invoke(_currentNumber);

        _isCoroutineRun = false;
    }
}