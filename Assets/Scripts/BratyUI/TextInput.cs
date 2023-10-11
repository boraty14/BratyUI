using System;
using BratyUI.Attributes;
using TMPro;
using UnityEngine;

namespace BratyUI
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextInput : ComponentBase
    {
        [SerializeField] [ShowOnly] private TMP_Text _text;

        private void OnValidate()
        {
            if (_text == null)
            {
                _text = GetComponent<TMP_Text>();
            }
        }
    }
}
