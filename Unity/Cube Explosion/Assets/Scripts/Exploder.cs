using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    private float cubeSize;

    public void Explode(float size)
    {
        cubeSize = size;

        foreach (Rigidbody rigidbody in GetRigidbodies())
            rigidbody.AddExplosionForce(_force / cubeSize, transform.position, _radius / cubeSize);
    }

    private List<Rigidbody> GetRigidbodies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius / cubeSize);

        return colliders
            .Where(hit => hit.attachedRigidbody)
            .Select(hit => hit.attachedRigidbody)
            .ToList();
    }
}