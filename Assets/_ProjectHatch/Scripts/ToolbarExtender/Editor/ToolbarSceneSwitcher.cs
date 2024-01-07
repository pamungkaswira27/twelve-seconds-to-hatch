using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityToolbarExtender;

namespace ProjectHatch.Editor.Toolbar
{
    [InitializeOnLoad]
    public class ToolbarSceneSwitcher
    {
        static ToolbarSceneSwitcher()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();

            if (GUILayout.Button(new GUIContent("Menu", "Menu")))
            {
                EditorSceneManager.OpenScene("Assets/_ProjectHatch/Scenes/Menu.unity");
            }

            if (GUILayout.Button(new GUIContent("Game", "Game")))
            {
                EditorSceneManager.OpenScene("Assets/_ProjectHatch/Scenes/Game.unity");
            }
        }
    }
}
