using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Painter _painter;
    [SerializeField] private Scaler _scaler;

    public float DivideChance { get; private set; } = 1;
    
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Die()
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