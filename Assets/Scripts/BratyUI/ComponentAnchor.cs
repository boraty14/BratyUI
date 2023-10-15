using BratyUI.Attributes;
using UnityEngine;

namespace BratyUI
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    public class ComponentAnchor : MonoBehaviour
    {
        [SerializeField] [ShowOnly] private Transform _transform;
        [SerializeField] private Vector2 _anchorPoint = Vector2.one * 0.5f;
        [SerializeField] private Vector2 _offset;
        private Vector3 _lastPosition;

        private Transform AnchorTransform
        {
            get
            {
                if (_transform == null)
                {
                    _transform = GetComponent<Transform>();
                }

                return _transform;
            }
        }

        private void Awake()
        {
            SetAnchorPosition();
        }

        private void OnEnable()
        {
            BratyUIEvents.OnCameraUpdate += OnCameraUpdate;
        }

        private void OnDisable()
        {
            BratyUIEvents.OnCameraUpdate -= OnCameraUpdate;
        }

        private void OnCameraUpdate()
        {
            SetAnchorPosition();
        }

        private void OnValidate()
        {
            SetAnchorPosition();
        }

        private void SetAnchorPosition()
        {
            Vector2 anchoredPosition;
            var referenceCamera = BratyCamera.Instance.ReferenceCamera;
            float orthographicSize = referenceCamera.orthographicSize;
            anchoredPosition.x = referenceCamera.aspect * orthographicSize * 2f * (_anchorPoint.x - 0.5f);
            anchoredPosition.y = orthographicSize * 2f * (_anchorPoint.y - 0.5f);
            anchoredPosition.x += _offset.x; 
            anchoredPosition.y += _offset.y;
            AnchorTransform.position = anchoredPosition;
        }
    }
}