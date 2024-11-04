using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    public List<Cube> GenerateCubes(Cube cube)
    {
        List<Cube> cubes = new();

        int quantity = GetQuantity();
        float divideChance = cube.DivideChance;

        for (int i = 0; i < quantity; i++)
        {
            cubes.Add(CreateCube(cube, divideChance));
        }

        return cubes;
    }

    private Cube CreateCube(Cube cube, float divideChance)
    {
        float halvedChance = divideChance / 2;

        Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);

        newCube.Initialise(halvedChance);

        return newCube;
    }


    private int GetQuantity()
    {
        int minQuantity = 2;
        int maxQuantity = 6;

        return Random.Range(minQuantity, maxQuantity + 1);
    }
}