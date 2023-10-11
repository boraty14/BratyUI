using BratyUI.Attributes;
using UnityEngine;

namespace BratyUI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class ComponentBase : MonoBehaviour
    {
        [SerializeField] [ShowOnly] private Vector2 _pivot;
        [SerializeField] [ShowOnly] private Transform _transform;
        [SerializeField] [ShowOnly] private SpriteRenderer _renderer;

        public Vector2 GetPivot() => _pivot;
        public Transform GetTransform() => _transform;
        public SpriteRenderer GetRenderer() => _renderer;

        protected virtual void OnValidate()
        {
            if (_transform == null)
            {
                _transform = transform;
            }

            if (_renderer == null)
            {
                _renderer = GetComponent<SpriteRenderer>();
            }

            if (_renderer.sprite == null)
            {
                return;
            }

            var sprite = _renderer.sprite;
            var spritePivot = sprite.pivot;
            var spriteTexture = sprite.texture;
            _pivot.x = spritePivot.x / spriteTexture.width;
            _pivot.y = spritePivot.y / spriteTexture.height;
        }
    }
}