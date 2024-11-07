using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    public void GenerateCubes(Cube cube)
    {
        int quantity = GetQuantity();
        float divideChance = cube.DivideChance;

        for (int i = 0; i < quantity; i++)
        {
            CreateCube(cube, divideChance);
        }
    }

    private void CreateCube(Cube cube, float divideChance)
    {
        float halvedChance = divideChance / 2;

        Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);

        newCube.Initialise(halvedChance);
    }

    private int GetQuantity()
    {
        int minQuantity = 2;
        int maxQuantity = 6;

        return Random.Range(minQuantity, maxQuantity + 1);
    }
}