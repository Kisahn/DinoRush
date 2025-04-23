using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class MissingScriptCleanerProject
{
    [MenuItem("Tools/Clean Missing Scripts In Project %#&m")] // Ctrl+Shift+Alt+M
    public static void CleanMissingScriptsInProject()
    {
        string[] prefabPaths = Directory.GetFiles("Assets", "*.prefab", SearchOption.AllDirectories);
        int totalRemoved = 0;

        foreach (string path in prefabPaths)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null) continue;

            int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(prefab);
            if (removed > 0)
            {
                Debug.Log($"Removed {removed} missing script(s) from prefab: {path}");
                totalRemoved += removed;
                EditorUtility.SetDirty(prefab);
            }
        }

        AssetDatabase.SaveAssets();
        Debug.Log($"Project cleanup complete. Total missing scripts removed: {totalRemoved}");
    }
}
