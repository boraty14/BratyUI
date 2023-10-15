using System;
using UnityEngine;

namespace BratyUI
{
    [Serializable]
    public class AnchorSettings
    {
        public Vector2 MinAnchor;
        public Vector2 MaxAnchor;
        public Vector2 AnchoredPosition;
        
        public Vector2 CurrentAnchor => (MinAnchor + MaxAnchor) / 2f;
    }
}
