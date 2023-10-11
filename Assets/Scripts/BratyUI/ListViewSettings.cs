using UnityEngine;

namespace BratyUI
{
    public class ListViewSettings
    {
        public EListDirection ListDirection = EListDirection.Vertical;
        public float ScrollSpeed = 1f;
        public bool IsElastic = true;
        [Range(0.05f, 1f)] public float SlowingFactor;
    }
    
    public enum EListDirection
    {
        Vertical,
        Horizontal
    }
}
