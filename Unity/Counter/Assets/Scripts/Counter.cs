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

    public event Action<float> NumberChanged;

    public float StartNumber => _startNumber;

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
        const int LeftMouseInput = 0;

        if (Input.GetMouseButtonDown(LeftMouseInput))
            UpdateState();
    }

    private void UpdateState()
    {
        _isRun = !_isRun;

        if (_isRun)
        {
            if (_countdownCoroutine == null)
                _countdownCoroutine = StartCoroutine(DelayedAddNumber());
        }
        else if (!_isRun)
        {
            if (_countdownCoroutine != null)
            {
                StopCoroutine(_countdownCoroutine);
                _countdownCoroutine = null;
            }
        }
    }

    private IEnumerator DelayedAddNumber()
    {
        WaitForSeconds countdownTime = new WaitForSeconds(_countdownTime);
        
        while (_isRun)
        {
            yield return countdownTime;
            _currentNumber += _numberToAdd;
            NumberChanged?.Invoke(_currentNumber);
        }
    }
}