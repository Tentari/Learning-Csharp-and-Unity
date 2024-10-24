using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countdownTime;
    [SerializeField] private float _startNumber;
    [SerializeField] private float _numberToAdd;

    private float _currentNumber;
    private bool _isRun;
    private Coroutine _countdownCoroutine;

    public float StartNumber => _startNumber;

    public event Action<float> NumberChanged;

    private void Start()
    {
        _currentNumber = _startNumber;
    }

    private void Update()
    {
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
            UpdateState();
    }

    private void UpdateState()
    {
        _isRun = !_isRun;

        if (_isRun)
        {
            if (_countdownCoroutine != null)
            {
                StopCoroutine(_countdownCoroutine);
            }
            
            _countdownCoroutine = StartCoroutine(DelayedAddNumber());
        }
        else if (!_isRun && _countdownCoroutine != null)
        {
            StopCoroutine(_countdownCoroutine);
            _countdownCoroutine = null;
        }
    }

    private IEnumerator DelayedAddNumber()
    {
        while (_isRun)
        {
            yield return new WaitForSeconds(_countdownTime);
            _currentNumber += _numberToAdd;
            NumberChanged?.Invoke(_currentNumber);
        }
    }
}