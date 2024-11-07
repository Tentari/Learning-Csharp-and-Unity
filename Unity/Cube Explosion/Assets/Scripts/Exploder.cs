using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void Explode(float size)
    {
        foreach (Rigidbody rigidbody in GetRigidbodies())
            rigidbody.AddExplosionForce(_force / size, transform.position, _radius / size);
    }

    private List<Rigidbody> GetRigidbodies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        return colliders
            .Where(hit => hit.attachedRigidbody)
            .Select(hit => hit.attachedRigidbody)
            .ToList();
    }
}