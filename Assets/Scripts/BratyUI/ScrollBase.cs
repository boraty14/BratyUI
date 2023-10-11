using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    public abstract class ScrollBase : ComponentBase, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.LogError(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
        }
    }
}
