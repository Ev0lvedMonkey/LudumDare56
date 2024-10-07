using UnityEngine;

public class VirusMover : MonoBehaviour
{
    [SerializeField] private bool _isVertical;
    [SerializeField] private float speed;

    private Vector2 direction;

    private void Start()
    {
        speed = Random.Range(1.3f, 1.9f);

        direction = _isVertical ? Vector2.up : Vector2.left;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Quaternion.Euler(0, 0, 180) * direction;
    }


}
