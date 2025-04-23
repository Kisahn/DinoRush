using UnityEditor;
using UnityEngine;

public static class ApplyAllOverridesInScene
{
    [MenuItem("Tools/Apply All Prefab Overrides In Scene")]
    public static void ApplyAllOverrides()
    {
        int count = 0;

        foreach (GameObject go in Object.FindObjectsOfType<GameObject>(true))
        {
            if (PrefabUtility.IsPartOfPrefabInstance(go))
            {
                GameObject prefabRoot = PrefabUtility.GetCorrespondingObjectFromOriginalSource(go);
                var prefabAssetType = PrefabUtility.GetPrefabAssetType(prefabRoot);

                // Only apply if it's a regular Unity prefab (not a model prefab)
                if (prefabAssetType == PrefabAssetType.Regular || prefabAssetType == PrefabAssetType.Variant)
                {
                    if (PrefabUtility.HasPrefabInstanceAnyOverrides(go, false))
                    {
                        PrefabUtility.ApplyPrefabInstance(go, InteractionMode.UserAction);
                        count++;
                    }
                }
            }
        }

        Debug.Log($"Overrides appliqués sur {count} prefab(s) dans la scène.");
    }
}
