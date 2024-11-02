using System;
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

    private void DrawRaycast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        
        if(Physics.Raycast(_ray, out hit, _maxDistance))
        {
            Cube cube = hit.collider.GetComponent<Cube>();

            if (cube)
            {
                CubeClicked?.Invoke(cube);
            }
        }
    }

    private void GetMouseInput()
    {
        if(Input.GetMouseButtonDown(LeftClickCommand))
            DrawRaycast();
    }
}