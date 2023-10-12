using System;
using BratyUI.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BratyUI
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextInput : InteractableBase,IPointerClickHandler
    {
        [SerializeField] [ShowOnly] private TMP_Text _text;
        [SerializeField] private string _placeHolder;
        private TouchScreenKeyboard _keyboard;
        private string _currentText;

        private void OnEnable()
        {
            _text.text = _placeHolder;
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_text == null)
            {
                _text = GetComponent<TMP_Text>();
            }
        }

        private void Update()
        {
            if (_keyboard == null)
            {
                return;
            }
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}
