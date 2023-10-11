using TMPro;
using UnityEngine;

public class TryKeyboard : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    [SerializeField] private TMP_Text _tmpText;
    // Updates button's text while user is typing

    private void Awake()
    {
        TouchScreenKeyboard.hideInput = true;
        keyboard = TouchScreenKeyboard.Open("");
    }

    private void Update()
    {
        if (keyboard != null)
        {
            _tmpText.text = keyboard.text;
        }
    }
}