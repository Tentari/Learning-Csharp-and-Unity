using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Painter _painter;
    [SerializeField] private Scaler _scaler;

    public float DivideChance { get; private set; } = 1;

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Initialise(float divideChance)
    {
        DivideChance = divideChance;
        _painter.Paint();
        _scaler.DivideScale();
    }
}