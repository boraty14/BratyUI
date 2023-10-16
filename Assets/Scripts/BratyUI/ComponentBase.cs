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
        [SerializeField] protected AnchorSettings AnchorSettings = new();

        private void Awake()
        {
            UpdateUI();
        }

        private void OnSpriteChange(SpriteRenderer spriteRenderer)
        {
            UpdateUI();
        }

        protected virtual void OnEnable()
        {
            _spriteRenderer.RegisterSpriteChangeCallback(OnSpriteChange);
            BratyUIEvents.OnCameraUpdate += OnCameraUpdate;
        }

        protected virtual void OnDisable()
        {
            _spriteRenderer.UnregisterSpriteChangeCallback(OnSpriteChange);
            BratyUIEvents.OnCameraUpdate -= OnCameraUpdate;
        }

        private void OnCameraUpdate()
        {
            UpdateUI();
        }

        private void OnValidate()
        {
            UpdateUI();
        }

        protected virtual void UpdateUI()
        {
            SetAnchoredPosition();
        }

        private void SetAnchoredPosition()
        {
            var uiShape = GetComponentUIShape();
            Transform.localPosition = uiShape.Position;
            ComponentRenderer.size = uiShape.Scale;
            var children = GetComponentsInChildren<ComponentBase>(true);
            foreach (var child in children)
            {
                if (child == this)
                {
                    continue;
                }
                child.SetAnchoredPosition();       
            }
        }

        private UIShape GetComponentUIShape()
        {
            var imageTexture = ComponentRenderer.sprite.texture;
            Vector2 rendererSize = new Vector2(imageTexture.width / 100f, imageTexture.height / 100f);
            var result = AnchorHelper.GetComponentUIShape(AnchorSettings,rendererSize,Transform);
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
                }

                return _spriteRenderer;
            }
        }
    }
}