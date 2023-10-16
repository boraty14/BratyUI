using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    public abstract class ScrollBase : ComponentBase, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] protected ScrollSettings ScrollSettings;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
}
