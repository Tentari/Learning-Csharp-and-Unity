using UnityEngine;

public class Resizer : MonoBehaviour
{
    [SerializeField] private float _resizeAmount;
    
    private void Update()
    {
        Resize();
    }

    private void Resize()
    {
        transform.localScale += Vector3.one * _resizeAmount;
    }
}
