using System;
using UnityEngine;

namespace BratyUI
{
    [Serializable]
    public class ScrollSettings
    {
        public EScrollDirection ScrollDirection = EScrollDirection.Vertical;
        public float ScrollSlowingAcceleration = 10f;
        public bool IsElastic = true;
        [Range(0.05f, 1f)] public float SlowingFactor;
    }
    
    [Serializable]
    public enum EScrollDirection
    {
        Vertical,
        Horizontal
    }
}
