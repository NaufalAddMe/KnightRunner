using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        float leftLimit = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f;
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
