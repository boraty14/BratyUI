using System;
using UnityEngine;

namespace BratyUI
{
    [Serializable]
    public class ButtonAnimationSettings
    {
        public bool IsChangingSize = true;
        public bool IsChangingColor = false;
        public bool IsChangingSprite = false;
        
        public ButtonStateSettings Normal;
        public ButtonStateSettings Highlighted;
        public ButtonStateSettings Pressed;
        public ButtonStateSettings Selected;
        public ButtonStateSettings Disabled;

        public ButtonStateSettings GetStateAnimationSettings(EButtonState buttonState)
        {
            return buttonState switch
            {
                EButtonState.Normal => Normal,
                EButtonState.Highlighted => Highlighted,
                EButtonState.Pressed => Pressed,
                EButtonState.Selected => Selected,
                EButtonState.Disabled => Disabled,
                _ => throw new ArgumentOutOfRangeException(nameof(buttonState), buttonState, null)
            };
        }
    }

    [Serializable]
    public class ButtonStateSettings
    {
        public float Size = 1f;
        public Color Color = Color.white;
        public Sprite Sprite;
    }

    [Serializable]
    public enum EButtonState
    {
        Normal,
        Highlighted,
        Pressed,
        Selected,
        Disabled
    }
}