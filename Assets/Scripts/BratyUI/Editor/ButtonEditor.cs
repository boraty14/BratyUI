using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace BratyUI.Editor
{
    // [CustomPropertyDrawer(typeof(Button))]
    // public class ButtonEditor : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         //return new PropertyField(property);
    //
    //         var root = new VisualElement();
    //         
    //         root.Add(new PropertyField(property.FindPropertyRelative("_transform")));
    //         root.Add(new PropertyField(property.FindPropertyRelative("InteractionCollider")));
    //
    //         var buttonSetting = new List<TreeViewItemData<float>>();
    //         for (int i = 0; i < 3; i++)
    //         {
    //             var treeElement = 
    //         }
    //         
    //         var buttonSettings = new PropertyField(property.FindPropertyRelative("Button Settings"));
    //         root.Add(buttonSettings);
    //         
    //         var dropdown = new DropdownField("Button Settings", new List<string> { "Option 1", "Option 2", "Option 3" }, 0);
    //         root.Add(dropdown);
    //     }
    // }
}
