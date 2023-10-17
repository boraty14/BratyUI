using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    public abstract class ScrollBase : InteractableBase, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] protected ScrollSettings ScrollSettings;
        [SerializeField] protected Image ScrollArea;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
            var delta = eventData.delta;
            var camera = BratyCamera.Instance.ReferenceCamera;
            delta.x *= camera.orthographicSize * camera.aspect * 2f / camera.pixelWidth;
            delta.y *= camera.orthographicSize * 2f / camera.pixelHeight;
            ScrollArea.ChangePosition(delta);
        }
    }
}
