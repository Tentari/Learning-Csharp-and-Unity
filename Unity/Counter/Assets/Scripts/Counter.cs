using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countdownTime;
    [SerializeField] private float _numberToAdd;
    
    [field: SerializeField] public float StartNumber { get; private set; }

    private const int LeftClickCommand = 0;

    private float _currentNumber;
    private Coroutine _countdownCoroutine;

    public event Action<float> NumberChanged;

    private void Start()
    {
        _currentNumber = StartNumber;
    }

    private void Update()
    {
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(LeftClickCommand))
            UpdateState();
    }

    private void UpdateState()
    {
        if (_countdownCoroutine == null)
        {
            _countdownCoroutine = StartCoroutine(DelayedAddNumber());
        }
        else if (_countdownCoroutine != null)
        {
            StopCoroutine(_countdownCoroutine);
            _countdownCoroutine = null;
        }
    }

    private IEnumerator DelayedAddNumber()
    {
        WaitForSeconds countdownTime = new WaitForSeconds(_countdownTime);

        do
        {
            yield return countdownTime;
            _currentNumber += _numberToAdd;
            NumberChanged?.Invoke(_currentNumber);
        } while (_countdownCoroutine != null);
    }
}