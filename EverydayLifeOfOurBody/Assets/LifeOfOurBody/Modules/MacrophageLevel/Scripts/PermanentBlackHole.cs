using UnityEngine;

public class PermanentBlackHole : MonoBehaviour
{
    public float pullForce = 20f;
    private CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, circleCollider.radius);
        foreach (var collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (Vector2)transform.position - rb.position;
                rb.AddForce(direction.normalized * pullForce);

                if (Vector2.Distance(transform.position, rb.position) < 0.3f)
                {
                    rb.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        if (circleCollider != null)
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
    }
}
