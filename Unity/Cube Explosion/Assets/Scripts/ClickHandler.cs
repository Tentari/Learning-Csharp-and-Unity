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
        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxDistance))
            return hit.collider.GetComponent<Cube>();

        return null;
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(SplitCubeCommand))
        {
            Cube cube = GetCube();

            if (cube)
            {
                if (CanDivide(cube.DivideChance))
                    _exploder.Explode(_cubeSpawner.GenerateCubes(cube));

                cube.Die();
            }
        }
    }
}