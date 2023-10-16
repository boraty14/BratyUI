using UnityEngine;

namespace BratyUI
{
    public struct UIShape
    {
        public Vector3 Position;
        public Vector3 Scale;

        public override string ToString()
        {
            return $"{nameof(Position)} : {Position}, {nameof(Scale)} : {Scale}";
        }
    }
}
