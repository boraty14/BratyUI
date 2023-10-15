using BratyUI.Attributes;
using UnityEngine;

namespace BratyUI
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class InteractableBase : ComponentBase
    {
        [SerializeField] [ShowOnly] private BoxCollider2D _collider;

        public BoxCollider2D InteractionCollider
        {
            get
            {
                if (_collider == null)
                {
                    _collider = GetComponent<BoxCollider2D>();
                    _collider.size = ComponentRenderer.bounds.size;
                    _collider.isTrigger = true;
                }

                return _collider;
            }
        }
    }
}