using BratyUI.Attributes;
using BratyUI.Helpers;
using UnityEngine;

namespace BratyUI
{
    [DefaultExecutionOrder(-100)]
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(ResolutionChangeHandler))]
    public class BratyCamera : MonoBehaviourSingletonPersistent<BratyCamera>
    {
        [SerializeField] [ShowOnly] private Camera _camera;
        [SerializeField] private float _size;
        [SerializeField] [Range(0f, 1f)] private float _horizontalWeight;

        public Camera GetReferenceCamera() => _camera;

        public override void Awake()
        {
            base.Awake();
            _camera = GetComponent<Camera>();
            SetCameraSize();
        }

        private void OnValidate()
        {
            SetCameraSize();
        }

        private void SetCameraSize()
        {
            float horizontalSize = (1f / _camera.aspect) * _size;
            float cameraSize = Mathf.Lerp(_size, horizontalSize, _horizontalWeight);
            _camera.orthographicSize = cameraSize;
        }
    }
}