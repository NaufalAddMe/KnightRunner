using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnInterval = 2f;
    public float spawnHeight = 0f; // Tetap di tinggi tertentu

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= spawnInterval)
        {
            SpawnPlatform();
            _timer = 0f;
        }
    }

    void SpawnPlatform()
    {
        float rightEdge = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 1f;
        float y = spawnHeight;
        Instantiate(platformPrefab, new Vector3(rightEdge, y, 0), Quaternion.identity);
    }
}
