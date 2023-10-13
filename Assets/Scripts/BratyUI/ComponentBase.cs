using System;
using BratyUI.Attributes;
using UnityEngine;

namespace BratyUI
{
    [DisallowMultipleComponent]
    public abstract class ComponentBase : MonoBehaviour
    {
        [SerializeField] [ShowOnly] private Transform _transform;

        protected virtual void OnValidate()
        {
            if (_transform == null)
            {
                _transform = transform;
            }
        }

        public Transform GetTransform()
        {
            if (_transform == null)
            {
                _transform = transform;
            }

            return _transform;
        }
    }
}