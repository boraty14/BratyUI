using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Button : InteractableBase, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField] protected ButtonAnimationSettings AnimationSettings = new();
        protected EButtonState ButtonState = EButtonState.Normal;
        public Action OnClicked;

        protected override void Awake()
        {
            base.Awake();
            InitButton();
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            InitButton();
        }

        private void InitButton()
        {
            var state = InteractionCollider.enabled ? EButtonState.Normal : EButtonState.Disabled;
            SetButtonState(state);
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
                Transform.localScale = animationSettings.Size * Vector3.one;
            }
            if (AnimationSettings.IsChangingColor)
            {
                ComponentRenderer.color = animationSettings.Color;
            }
            if (AnimationSettings.IsChangingSprite)
            {
                ComponentRenderer.sprite = animationSettings.Sprite;
            }
            ButtonState = buttonState;
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