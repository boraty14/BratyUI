using UnityEngine;

namespace BratyUI.Helpers
{
    public static class AnchorHelper
    {
        private const float Tolerance = 0.01f;

        public static UIShape GetComponentUIShape(AnchorSettings anchorSettings, Vector2 rendererSize)
        {
            UIShape uiShape;
            Vector2 anchoredPosition;
            var referenceCamera = BratyCamera.Instance.ReferenceCamera;
            float orthographicSize = referenceCamera.orthographicSize;
            float verticalScreenSize = orthographicSize;
            float horizontalScreenSize = orthographicSize * referenceCamera.aspect;
            
            // set position
            anchoredPosition.x = horizontalScreenSize * 2f * (anchorSettings.CurrentAnchor.x - 0.5f);
            anchoredPosition.x += anchorSettings.AnchoredPosition.x;
            anchoredPosition.y = verticalScreenSize * 2f * (anchorSettings.CurrentAnchor.y - 0.5f);
            anchoredPosition.y += anchorSettings.AnchoredPosition.y;
            uiShape.Position = anchoredPosition;
            
            // set scale
            uiShape.Scale = new Vector3(anchorSettings.Scale.x,anchorSettings.Scale.y,1f);

            if (anchorSettings.HorizontalAnchorDistance > Tolerance)
            {
                float horizontalItemSize = anchorSettings.HorizontalAnchorDistance * horizontalScreenSize * 2f;
                float horizontalScale = horizontalItemSize / rendererSize.x;
                uiShape.Scale.x *= horizontalScale;
            }
            
            if (anchorSettings.VerticalAnchorDistance > Tolerance)
            {
                float verticalItemSize = anchorSettings.VerticalAnchorDistance * verticalScreenSize * 2f;
                float verticalScale = verticalItemSize / rendererSize.y;
                uiShape.Scale.y *= verticalScale;
                
            }
            return uiShape;
        }
    }
}