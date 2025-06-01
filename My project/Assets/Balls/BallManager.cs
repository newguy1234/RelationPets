using UnityEngine;

public class StackSpawner : MonoBehaviour
{
    [Header("Stack Settings")]
    public GameObject prefab;         // Prefab to spawn
    public int stackCount = 5;        // Number of prefabs to spawn in the stack
    public float verticalSpacing = 1f; // Space between stacked prefabs

    void Start()
    {
        if (prefab == null)
        {
            Debug.LogWarning("No prefab assigned!");
            return;
        }

        for (int i = 0; i < stackCount; i++)
        {
            Vector3 spawnPosition = transform.position + Vector3.right * verticalSpacing * i;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }


}
