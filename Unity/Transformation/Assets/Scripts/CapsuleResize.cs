using UnityEngine;

public class CapsuleResize : MonoBehaviour
{
    [SerializeField] private float _resizeAmount;
    [SerializeField] private float _timer;

    private float _originalTimer;

    private void Start()
    {
        _originalTimer = _timer;
    }

    private void Update()
    {
        Resize();
        TickTimer();
        ChangeDirectionOnTimer();
    }

    private void Resize()
    {
        transform.localScale += Vector3.one * _resizeAmount;
    }

    private void TickTimer()
    {
        _timer -= Time.deltaTime;
    }

    private void ChangeDirectionOnTimer()
    {
        if (_timer <= 0)
        {
            _resizeAmount *= -1f;
            _timer = _originalTimer;
        }
    }
}