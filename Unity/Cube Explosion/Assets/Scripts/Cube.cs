using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Painter _painter;
    [SerializeField] private Scaler _scaler;
    [SerializeField] private Exploder _exploder;

    public float DivideChance { get; private set; } = 1;

    private void OnDisable()
    {
        _exploder.Explode();
    }

    public void Destroy()
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