using UnityEngine;
using UnityEditor;

public static class MissingScriptCleaner
{
    [MenuItem("Tools/Clean Missing Scripts In Scene %#m")] // Ctrl+Shift+M
    public static void CleanAllMissingScriptsInScene()
    {
        int total = 0;

        foreach (GameObject go in Object.FindObjectsOfType<GameObject>(true)) // include inactive
        {
            int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
            if (removed > 0)
            {
                Debug.Log($"Removed {removed} missing script(s) from '{go.name}'", go);
                total += removed;
            }
        }

        Debug.Log($"Cleanup complete. {total} missing script(s) removed from the scene.");
    }
}
