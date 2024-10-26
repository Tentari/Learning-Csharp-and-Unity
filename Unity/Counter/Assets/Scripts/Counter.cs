using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int LeftClickCommand = 0;

    [SerializeField] private float _countdownTime;
    [SerializeField] private float _numberToAdd;

    private float _currentNumber;
    private Coroutine _countdownCoroutine;

    public event Action<float> NumberChanged;

    [field: SerializeField] public float StartNumber { get; private set; }

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
        else
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