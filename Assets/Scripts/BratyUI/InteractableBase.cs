using BratyUI.Attributes;
using UnityEngine;

namespace BratyUI
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class InteractableBase : ComponentBase
    {
        [SerializeField] [ShowOnly] protected Collider2D InteractionCollider;

        protected virtual void OnValidate()
        {
            if (InteractionCollider == null)
            {
                InteractionCollider = GetComponent<Collider2D>();
                InteractionCollider.isTrigger = true;
            }
        }
    }
}