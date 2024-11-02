using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_force, transform.position, _radius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> objects = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody)
                objects.Add(hit.attachedRigidbody);
        }

        return objects;
    }
}