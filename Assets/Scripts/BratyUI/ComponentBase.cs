using BratyUI.Attributes;
using BratyUI.Helpers;
using UnityEngine;

namespace BratyUI
{
    [RequireComponent(typeof(SpriteRenderer))]
    [DisallowMultipleComponent]
    public abstract class ComponentBase : MonoBehaviour
    {
        [SerializeField] [ShowOnly] private Transform _transform;
        [SerializeField] [ShowOnly] private SpriteRenderer _spriteRenderer;
        [SerializeField] private AnchorSettings _anchorSettings = new();

        protected virtual void Awake()
        {
            SetAnchoredPosition();
        }

        protected virtual void OnValidate()
        {
            SetAnchoredPosition();
        }

        private void SetAnchoredPosition()
        {
            var uiShape = AnchorHelper.GetComponentUIShape(_anchorSettings);
            Transform.position = uiShape.Position;
            Transform.localScale = uiShape.Scale;
        }

        public Transform Transform
        {
            get
            {
                if (_transform == null)
                {
                    _transform = transform;
                }

                return _transform;
            }
        }

        public SpriteRenderer ComponentRenderer
        {
            get
            {
                if (_spriteRenderer == null)
                {
                    _spriteRenderer = GetComponent<SpriteRenderer>();
                    _spriteRenderer.sprite = Resources.Load<Sprite>("Textures/White_64x64");
                    //_spriteRenderer.sprite = Resources.Load<Sprite>("Textures/download-removebg-preview");
                }

                return _spriteRenderer;
            }
        }
    }
}