using BratyUI.Attributes;
using BratyUI.Helpers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    [ExecuteAlways]
    [DefaultExecutionOrder(-100)]
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(Physics2DRaycaster))]
    public class BratyCamera : MonoBehaviourSingleton<BratyCamera>
    {
        [SerializeField] [ShowOnly] private Camera _camera;
        [SerializeField] private float _size;
        [SerializeField] [Range(0f, 1f)] private float _horizontalWeight;
        private int _lastScreenWidth;
        private int _lastScreenHeight;

        public Camera ReferenceCamera
        {
            get
            {
                if (_camera == null)
                {
                    _camera = GetComponent<Camera>();
                }

                return _camera;
            }
        }

        private void Awake()
        {
            SetCameraSize();
        }

        private void OnValidate()
        {
            SetCameraSize();
        }

        private void Update()
        {
            CheckResolutionChange();
        }

        private void CheckResolutionChange()
        {
            if (_lastScreenWidth != ReferenceCamera.pixelWidth ||
                _lastScreenHeight != ReferenceCamera.pixelHeight)
            {
                SetCameraSize();
                Debug.Log(
                    $"Resolution changed! New resolution is {_lastScreenWidth}x{_lastScreenHeight} Aspect ratio: {ReferenceCamera.aspect}");
            }
        }

        private void SetCameraSize()
        {
            _lastScreenWidth = ReferenceCamera.pixelWidth;
            _lastScreenHeight = ReferenceCamera.pixelHeight;
            float horizontalSize = (1f / ReferenceCamera.aspect) * _size;
            float cameraSize = Mathf.Lerp(_size, horizontalSize, _horizontalWeight);
            ReferenceCamera.orthographicSize = cameraSize;
            BratyUIEvents.OnCameraUpdate?.Invoke();
        }
    }
}