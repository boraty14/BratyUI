using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    public abstract class ScrollBase : InteractableBase, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] protected ScrollSettings ScrollSettings;
        [SerializeField] protected Image ScrollArea;
        private Vector2 _lastDrag;
        private bool _isDragging;

        protected override void OnEnable()
        {
            base.OnEnable();
            _isDragging = false;
            _lastDrag = Vector2.zero;
        }

        private void Update()
        {
            if (ScrollSettings.IsElastic && !_isDragging && _lastDrag.sqrMagnitude > 0f)
            {
                MoveScrollArea(_lastDrag);
                _lastDrag = Vector2.Lerp(_lastDrag, Vector2.zero, Time.deltaTime * ScrollSettings.ScrollSlowingAcceleration);
                if (_lastDrag.sqrMagnitude < 0.05f)
                {
                    _lastDrag = Vector2.zero;
                }
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _lastDrag = Vector2.zero;
            _isDragging = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isDragging = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var delta = eventData.delta;
            _lastDrag = delta;
            MoveScrollArea(delta);
        }

        private void MoveScrollArea(Vector2 delta)
        {
            var camera = BratyCamera.Instance.ReferenceCamera;
            delta.x *= camera.orthographicSize * camera.aspect * 2f / camera.pixelWidth;
            delta.y *= camera.orthographicSize * 2f / camera.pixelHeight;
            if (ScrollSettings.ScrollDirection == EScrollDirection.Vertical)
            {
                delta.x = 0f;
            }
            else
            {
                delta.y = 0f;
            }

            ScrollArea.ChangePosition(delta);
        }
    }
}