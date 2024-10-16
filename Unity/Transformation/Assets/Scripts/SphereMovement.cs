using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class SphereMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _timer;

    private float _originalTimer;

    private void Start()
    {
        _originalTimer = _timer;
    }
    
    private void Update()
    {
        Move();
        Rotate();
        TickTimer();
        ChangeDirectionOnTimer();
    }

    private void Move()
    {
        transform.position += Vector3.forward * (_moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.right, _rotateSpeed * Time.deltaTime);
    }

    private void TickTimer()
    {
        _timer -= Time.deltaTime;
    }

    private void ChangeDirectionOnTimer()
    {
        if (_timer <= 0)
        {
            _rotateSpeed *= -1f;
            _moveSpeed *= -1f;
            _timer = _originalTimer;
        }
    }
}