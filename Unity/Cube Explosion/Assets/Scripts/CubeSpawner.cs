using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;

    private void OnEnable()
    {
        _rayCaster.CubeClicked += TryCreateCubes;
    }

    private void OnDisable()
    {
        _rayCaster.CubeClicked -= TryCreateCubes;
    }

    private void TryCreateCubes(Cube cube)
    {
        int quantity = GetQuantity();
        float divideChance = cube.DivideChance;

        if (CanDivide(divideChance))
        {
            for (int i = 0; i < quantity; i++)
            {
                CreateCube(cube, divideChance);
            }
        }

        cube.Destroy();
    }

    private void CreateCube(Cube cube, float divideChance)
    {
        float halvedChance = divideChance / 2;

        Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);

        newCube.Initialise(halvedChance);
    }

    private bool CanDivide(float divideChance)
    {
        return Random.value <= divideChance;
    }

    private int GetQuantity()
    {
        int minQuantity = 2;
        int maxQuantity = 6;

        return Random.Range(minQuantity, maxQuantity + 1);
    }
}