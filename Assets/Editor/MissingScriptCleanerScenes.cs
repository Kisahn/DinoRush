using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.IO;
using System.Linq;

public class MissingScriptCleanerScenes
{
    [MenuItem("Tools/Clean Missing Scripts In All Scenes %#&s")] // Ctrl+Shift+Alt+S
    public static void CleanAllScenes()
    {
        string[] scenePaths = Directory.GetFiles("Assets", "*.unity", SearchOption.AllDirectories);
        int totalRemoved = 0;

        foreach (string scenePath in scenePaths)
        {
            var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
            int sceneRemoved = 0;

            foreach (GameObject go in scene.GetRootGameObjects())
            {
                GameObject[] all = go.GetComponentsInChildren<Transform>(true)
                    .Select(t => t.gameObject).ToArray();

                foreach (GameObject obj in all)
                {
                    int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(obj);
                    sceneRemoved += removed;
                }
            }

            if (sceneRemoved > 0)
            {
                Debug.Log($"Cleaned {sceneRemoved} missing scripts in scene: {scenePath}");
                EditorSceneManager.SaveScene(scene);
            }

            totalRemoved += sceneRemoved;
        }

        Debug.Log($"All scenes cleaned. Total missing scripts removed: {totalRemoved}");
    }
}
