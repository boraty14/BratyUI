using UnityEditor;
using UnityEngine;

namespace BratyUI.Editor
{
    public static class ComponentMenuItemEditor
    {
        [MenuItem("GameObject/BratyUI/Canvas", false, 0)]
        private static void CreateCanvas(MenuCommand menuCommand)
        {
            // Create a custom game object
            GameObject go = new GameObject("BratyCanvas");
            go.AddComponent<Canvas>();
            CreateComponent(go, menuCommand);
        }

        [MenuItem("GameObject/BratyUI/Camera", false, 0)]
        private static void CreateCamera(MenuCommand menuCommand)
        {
            // Create a custom game object
            GameObject go = new GameObject("BratyCamera");
            go.AddComponent<BratyCamera>();
            CreateComponent(go, menuCommand);
        }

        [MenuItem("GameObject/BratyUI/Button", false, 10)]
        private static void CreateButton(MenuCommand menuCommand)
        {
            // Create a custom game object
            GameObject go = new GameObject("Button");
            go.AddComponent<Button>();
            CreateComponent(go, menuCommand);
        }

        [MenuItem("GameObject/BratyUI/TextInput", false, 10)]
        private static void CreateTextInput(MenuCommand menuCommand)
        {
            // Create a custom game object
            GameObject go = new GameObject("TextInput");
            go.AddComponent<BoxCollider2D>();
            go.AddComponent<TextInput>();
            CreateComponent(go, menuCommand);
        }

        [MenuItem("GameObject/BratyUI/Image", false, 10)]
        private static void CreateImage(MenuCommand menuCommand)
        {
            // Create a custom game object
            GameObject go = new GameObject("Image");
            go.AddComponent<Image>();
            CreateComponent(go, menuCommand);
        }

        [MenuItem("GameObject/BratyUI/ListView", false, 10)]
        private static void CreateListView(MenuCommand menuCommand)
        {
            // Create a custom game object
            GameObject go = new GameObject("ListView");
            go.AddComponent<ListView>();
            CreateComponent(go, menuCommand);
        }

        private static void CreateComponent(GameObject go, MenuCommand menuCommand)
        {
            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    }
}