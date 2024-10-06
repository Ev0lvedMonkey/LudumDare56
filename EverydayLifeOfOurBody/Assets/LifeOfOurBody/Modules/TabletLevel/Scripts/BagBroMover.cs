using UnityEngine;

public class BagBroMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationOffsetRange = 20f;
    private Vector2 direction;

    private void Start()
    {
        speed = Random.Range(4.2f, 5.5f);
        direction = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomOffset = Random.Range(-rotationOffsetRange, rotationOffsetRange);
        direction = Quaternion.Euler(0, 0, 180 + randomOffset) * direction;
    }
}
