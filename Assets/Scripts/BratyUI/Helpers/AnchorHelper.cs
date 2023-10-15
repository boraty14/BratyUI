using UnityEngine;

namespace BratyUI.Helpers
{
    public static class AnchorHelper
    {
        private const float Tolerance = 0.01f;

        public static UIShape GetComponentUIShape(AnchorSettings anchorSettings)
        {
            UIShape uiShape;
            Vector2 anchoredPosition;
            var referenceCamera = BratyCamera.Instance.ReferenceCamera;
            float orthographicSize = referenceCamera.orthographicSize;
            anchoredPosition.x = referenceCamera.aspect * orthographicSize * 2f * (anchorSettings.CurrentAnchor.x - 0.5f);
            anchoredPosition.x += anchorSettings.AnchoredPosition.x;
            anchoredPosition.y = orthographicSize * 2f * (anchorSettings.CurrentAnchor.y - 0.5f);
            anchoredPosition.y += anchorSettings.AnchoredPosition.y;
            uiShape.Position = anchoredPosition;
            uiShape.Scale = Vector3.one;
            
            if (!IsEqual(anchorSettings.MinAnchor.x, anchorSettings.MaxAnchor.x))
            {
                
            }

            if (!IsEqual(anchorSettings.MinAnchor.y, anchorSettings.MaxAnchor.y))
            {
            }

            return uiShape;
        }

        private static bool IsEqual(float a, float b)
        {
            return Mathf.Abs(a - b) < Tolerance;
        }
    }

    public struct UIShape
    {
        public Vector3 Position;
        public Vector3 Scale;
    }
}