using System;
using UnityEngine;

namespace BratyUI
{
    [Serializable]
    public class AnchorSettings
    {
        public Vector2 MinAnchor = Vector2.one * 0.5f;
        public Vector2 MaxAnchor = Vector2.one * 0.5f;
        public Vector2 Pivot = Vector2.one * 0.5f;
        public Vector2 AnchoredPosition = Vector2.zero;
        public Vector2 Scale = Vector2.one;
        
        public Vector2 CurrentAnchor => (MinAnchor + MaxAnchor) / 2f;

        public float VerticalAnchorDistance => Mathf.Abs(MinAnchor.y - MaxAnchor.y);
        public float HorizontalAnchorDistance => Mathf.Abs(MinAnchor.x - MaxAnchor.x);
    }
}
