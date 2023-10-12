using BratyUI.Attributes;
using UnityEngine;

namespace BratyUI
{
    [DisallowMultipleComponent]
    public class ComponentAnchor : MonoBehaviour
    {
        [SerializeField] [ShowOnly] private Camera _referenceCamera;
        [SerializeField] [Range(0f, 1f)] private float _scaleHorizontalWeight;
        [SerializeField] private Vector2 _anchorPoint;

        private void Awake()
        {
            SetAnchorPosition();
        }

        private void OnValidate()
        {
            SetAnchorPosition();
        }

        private void SetAnchorPosition()
        {
            if (_referenceCamera == null && !TrySettingCamera())
            {
                return;
            }
            
            
        }

        private bool TrySettingCamera()
        {
            var refCamera = FindFirstObjectByType<BratyCamera>().GetReferenceCamera();
            if (refCamera == null)
            {
                Debug.LogError("Camera not found for anchoring");
                return false;
            }

            _referenceCamera = refCamera;
            return true;
        }
    }
}