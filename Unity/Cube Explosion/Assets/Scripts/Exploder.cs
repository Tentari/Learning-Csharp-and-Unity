using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void Explode(List<Cube> cubes)
    {
        foreach (Rigidbody rigidbody in GetRigidbodies(cubes))
            rigidbody.AddExplosionForce(_force, transform.position, _radius);
    }

    private List<Rigidbody> GetRigidbodies(List<Cube> cubes)
    {
        List<Rigidbody> rigidbodies = new();

        foreach (Cube cube in cubes)
        {
            if (cube.Rigidbody)
            {
                rigidbodies.Add(cube.Rigidbody);
            }
        }

        return rigidbodies;
    }
}