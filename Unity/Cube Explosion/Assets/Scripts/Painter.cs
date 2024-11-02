using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer))]
public class Painter : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Paint()
    {
        _meshRenderer.material = GetRandomMaterial();
    }
    
    private Material GetRandomMaterial()
    {
        int randomIndex = Random.Range(0, _materials.Count);

        return _materials[randomIndex];
    }
}