using UnityEngine;
using Random = UnityEngine.Random;

public class ClickHandler : MonoBehaviour
{
    private const int SplitCubeCommand = 0;

    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;

    [SerializeField] private float _maxDistance;

    private void Update()
    {
        HandleMouseInput();
    }

    private bool CanDivide(float divideChance)
    {
        return Random.value <= divideChance;
    }

    private Cube GetCube()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        return Physics.Raycast(ray, out RaycastHit hit, _maxDistance) ? hit.collider.GetComponent<Cube>() : null;
    }

    private void HandleMouseInput()
    {
        if (!Input.GetMouseButtonDown(SplitCubeCommand)) return;
        
        Cube cube = GetCube();

        if (!cube) return;
        
        if (CanDivide(cube.DivideChance))
            _cubeSpawner.GenerateCubes(cube);
        else
            _exploder.Explode(cube.transform.localScale.x);

        cube.Die();
    }
}