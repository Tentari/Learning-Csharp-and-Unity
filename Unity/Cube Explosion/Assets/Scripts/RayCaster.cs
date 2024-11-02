﻿using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    private const int LeftClickCommand = 0;

    [SerializeField] private Camera _camera;

    [SerializeField] private float _maxDistance;

    private Ray _ray;

    public event Action<Cube> CubeClicked;

    private void Update()
    {
        GetMouseInput();
    }

    private void TryInvokeCubeEvent()
    {
        Cube cube = TryGetCube();

        if (cube)
            CubeClicked?.Invoke(cube);
    }

    private Cube TryGetCube()
    {
        CastRay();

        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, _maxDistance))
            return hit.collider.GetComponent<Cube>();

        return null;
    }

    private void CastRay()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
    }

    private void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(LeftClickCommand))
            TryInvokeCubeEvent();
    }
}