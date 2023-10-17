using BratyUI.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    [RequireComponent(typeof(TextMeshPro))]
    public class TextInput : InteractableBase, IPointerClickHandler
    {
        [SerializeField] [ShowOnly] private TextMeshPro _text;
        [SerializeField] [ShowOnly] private RectTransform _rectTransform;
        [SerializeField] private string _placeHolder;
        private TouchScreenKeyboard _keyboard;

        public string GetText()
        {
            if (_text == null)
            {
                _text = GetComponent<TextMeshPro>();
            }

            return _text.text;
        }

        protected override void UpdateUI()
        {
            base.UpdateUI();
            if (_text == null)
            {
                _text = GetComponent<TextMeshPro>();
            }

            _text.text = _placeHolder;

            if (_rectTransform == null)
            {
                _rectTransform = Transform as RectTransform;
            }
        }

        private void Update()
        {
            if (_keyboard == null)
            {
                return;
            }

            _text.text = _keyboard.text;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_keyboard != null)
            {
                return;
            }

            TouchScreenKeyboard.hideInput = true;
            _keyboard = TouchScreenKeyboard.Open("");
            _keyboard.text = _text.text;
        }
    }
}