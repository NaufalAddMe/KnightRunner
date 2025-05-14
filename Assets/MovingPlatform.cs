using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        float leftEdge = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 1f;

        if (transform.position.x < leftEdge)
        {
            // Sembunyikan platform
            if (_renderer != null) _renderer.enabled = false;
        }
        else
        {
            // Tampilkan kembali jika masuk layar
            if (_renderer != null) _renderer.enabled = true;
        }
    }
}
