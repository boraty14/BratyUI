using BratyUI.Attributes;
using BratyUI.Helpers;
using UnityEngine;

namespace BratyUI
{
    [ExecuteAlways]
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

        protected virtual void OnEnable()
        {
            BratyUIEvents.OnCameraUpdate += OnCameraUpdate;
        }

        protected virtual void OnDisable()
        {
            BratyUIEvents.OnCameraUpdate -= OnCameraUpdate;
        }

        private void OnCameraUpdate()
        {
            SetAnchoredPosition();
        }

        protected virtual void OnValidate()
        {
            SetAnchoredPosition();
        }

        private void SetAnchoredPosition()
        {
            var uiShape = GetComponentUIShape();
            Transform.position = uiShape.Position;
            ComponentRenderer.size = uiShape.Scale;
        }

        private UIShape GetComponentUIShape()
        {
            var imageTexture = ComponentRenderer.sprite.texture;
            Vector2 rendererSize = new Vector2(imageTexture.width / 100f, imageTexture.height / 100f);
            var result = AnchorHelper.GetComponentUIShape(_anchorSettings,rendererSize);
            return result;
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
                    _spriteRenderer.drawMode = SpriteDrawMode.Sliced;
                    _spriteRenderer.sprite = Resources.Load<Sprite>("Textures/White_64x64");
                    //_spriteRenderer.sprite = Resources.Load<Sprite>("Textures/download-removebg-preview");
                }

                return _spriteRenderer;
            }
        }
    }
}