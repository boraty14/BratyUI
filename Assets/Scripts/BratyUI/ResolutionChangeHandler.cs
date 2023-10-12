using BratyUI.Attributes;
using UnityEngine;

namespace BratyUI
{
    [ExecuteAlways]
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    public class ResolutionChangeHandler : MonoBehaviour
    {
        [SerializeField] [ShowOnly] private Camera _camera;
        private int _lastScreenWidth;
        private int _lastScreenHeight;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            CheckResolutionChange();
        }

        private void CheckResolutionChange()
        {
            if (_lastScreenWidth != _camera.pixelWidth ||
                _lastScreenHeight != _camera.pixelHeight)
            {
                _lastScreenWidth = _camera.pixelWidth;
                _lastScreenHeight = _camera.pixelHeight;
                BratyUIEvents.OnResolutionChange?.Invoke();
            }
        }
    }
}