using UnityEngine;

public class TryCam : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    //Set a fixed horizontal FOV
    [SerializeField] private float _horizontalFOV;

    private void Awake()
    {
        SetCamera();
    }

    private void OnValidate()
    {
        SetCamera();
    }

    private void SetCamera()
    {
        _camera.orthographicSize = calcVertivalFOV(_horizontalFOV, _camera.aspect);
    }

    private float calcVertivalFOV(float hFOVInDeg, float aspectRatio)
    {
        float hFOVInRads = hFOVInDeg * Mathf.Deg2Rad;
        float vFOVInRads = 2 * Mathf.Atan(Mathf.Tan(hFOVInRads / 2) / aspectRatio);
        float vFOV = vFOVInRads * Mathf.Rad2Deg;
        return vFOV;
    }
}