using BratyUI.Attributes;
using BratyUI.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace BratyUI
{
    [DefaultExecutionOrder(-100)]
    [RequireComponent(typeof(Camera))]
    public class BratyCamera : MonoBehaviourSingletonPersistent<BratyCamera>
    {
        [SerializeField] [ShowOnly] private Camera _camera;
        [SerializeField] private float _size;
        [SerializeField] [Range(0f, 1f)] private float _horizontalWeight;

        public Camera GetReferenceCamera() => _camera;

        public override void Awake()
        {
            base.Awake();
            SetCamera();
        }

        private void OnValidate()
        {
            SetCamera();
        }

        private void SetCamera()
        {
            _camera = GetComponent<Camera>();
            _camera.orthographicSize = CalculateCameraSize();
            Debug.LogError($"pixel width {_camera.pixelWidth} scaled pixel width {_camera.scaledPixelWidth}");
        }

        private float CalculateCameraSize()
        {
            float horizontalSize = (1f / _camera.aspect) * _size;
            float cameraSize = Mathf.Lerp(_size, horizontalSize, _horizontalWeight);
            return cameraSize;
        }
    }
}