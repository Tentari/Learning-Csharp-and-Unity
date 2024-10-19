using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Mover : MonoBehaviour
{
    private float _md oveSpee= 2f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * (_moveSpeed * Time.deltaTime));
    }
}