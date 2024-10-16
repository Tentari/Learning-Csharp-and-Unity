using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class SecondCubeBehavior : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _timer;
    [SerializeField] private float _resizeAmount;

    private float _originalTimer;

    private void Start()
    {
        _originalTimer = _timer;
    }

    private void Update()
    {
        Move();
        Rotate();
        Resize();
        TickTimer();
        ChangeDirectionOnTimer();
    }

    private void TickTimer()
    {
        _timer -= Time.deltaTime;
    }

    private void ChangeDirectionOnTimer()
    {
        if (_timer <= 0)
        {
            _resizeAmount *= -1;
            _timer = _originalTimer;
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * (_moveSpeed * Time.deltaTime));
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    private void Resize()
    {
        transform.localScale += Vector3.one * _resizeAmount;
    }
}