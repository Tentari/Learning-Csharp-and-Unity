using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _startNumber;
    [SerializeField] private float _numberToAdd;
    [SerializeField] private CounterView _counterView;

    private float _currentNumber;
    private bool _isRun;

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
        if (_isRun)
        {
            _currentNumber += _numberToAdd;

            NumberChanged?.Invoke(_currentNumber);
        }
    }

    private void UpdateState()
    {
        _isRun = !_isRun;
    }
}