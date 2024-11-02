using UnityEngine;

public class Scaler : MonoBehaviour
{
    public void DivideScale()
    {
        int divider = 2;
        transform.localScale /= divider;
    }
}