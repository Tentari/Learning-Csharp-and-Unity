using UnityEngine;

public class FirstCubeRotate : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, _speed * Time.deltaTime);
    }
}