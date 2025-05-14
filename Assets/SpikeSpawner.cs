using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject spikePrefab;
    public float spawnInterval = 2f;
    public float spawnY = -2.5f;
    public float spawnOffsetX = 10f;
    public int spawnCount = 1; // Jumlah spike yang ingin di-spawn sekaligus
    public float horizontalSpacing = 1.5f; // Jarak antar spike saat di-spawn bersamaan

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnSpikes();
            timer = 0f;
        }
    }

    void SpawnSpikes()
    {
        if (spikePrefab == null)
        {
            Debug.LogError("Spike prefab belum diisi di Inspector!");
            return;
        }

        float startX = Camera.main.transform.position.x + spawnOffsetX;

        for (int i = 0; i < spawnCount; i++)
        {
            float x = startX + i * horizontalSpacing;
            Vector3 spawnPos = new Vector3(x, spawnY, 0f);
            Instantiate(spikePrefab, spawnPos, Quaternion.identity);
        }
    }
}
