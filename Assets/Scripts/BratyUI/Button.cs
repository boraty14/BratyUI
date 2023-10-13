using System;
using BratyUI.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    [ExecuteAlways]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Button : InteractableBase, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField] [ShowOnly] private SpriteRenderer _renderer;
        [SerializeField] protected ButtonAnimationSettings AnimationSettings;
        protected EButtonState ButtonState = EButtonState.Normal;
        public Action OnClicked;

        private void Awake()
        {
            var state = InteractionCollider.enabled ? EButtonState.Normal : EButtonState.Disabled;
            SetButtonState(state);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_renderer == null)
            {
                _renderer = GetComponent<SpriteRenderer>();
            }
        }

        public void EnableButton()
        {
            InteractionCollider.enabled = true;
            SetButtonState(EButtonState.Normal);
        }
        
        public void DisableButton()
        {
            InteractionCollider.enabled = false;
            SetButtonState(EButtonState.Disabled);
        }

        public void ToggleSelection(bool isSelected)
        {
            var state = isSelected ? EButtonState.Selected : EButtonState.Normal;
            SetButtonState(state);
        }

        private void SetButtonState(EButtonState buttonState)
        {
            var animationSettings = AnimationSettings.GetStateAnimationSettings(buttonState);
            if (AnimationSettings.IsChangingSize)
            {
                GetTransform().localScale = animationSettings.Size * Vector3.one;
            }
            if (AnimationSettings.IsChangingColor)
            {
                _renderer.color = animationSettings.Color;
            }
            if (AnimationSettings.IsChangingSprite)
            {
                _renderer.sprite = animationSettings.Sprite;
            }
            ButtonState = buttonState;
        }

        private void Update()
        {
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("click");
            OnClicked?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("down");
            SetButtonState(EButtonState.Pressed);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("up");
            SetButtonState(EButtonState.Normal);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            SetButtonState(EButtonState.Highlighted);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            SetButtonState(EButtonState.Normal);
        }

    }
}