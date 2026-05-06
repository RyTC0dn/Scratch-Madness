using System.Collections;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float spawnInterval = 10f; // Time interval between spawns
    public float spawnTime = 5f; // Time before the first spawn

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(routine: SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        spawnTime -= Time.deltaTime; // Decrease the spawn time by the time elapsed since the last frame
        if (spawnTime <= 0)
        {
            // Spawn an enemy at the position of this GameObject
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnTime = spawnInterval; // Reset the spawn time to the specified interval
        }

        // Wait for the specified spawn interval before spawning the next enemy
        yield return new WaitForSeconds(spawnInterval);
    }
}