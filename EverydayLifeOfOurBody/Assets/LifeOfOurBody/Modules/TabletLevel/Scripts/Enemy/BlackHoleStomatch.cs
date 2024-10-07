using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleStomatch : MonoBehaviour
{
    public float pullForce = 20f; 
    public float pullRadius = 5f; 

    private List<Rigidbody2D> objectsInRange = new List<Rigidbody2D>(); 
    private bool isActive = false; 

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            objectsInRange.Add(rb);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null && objectsInRange.Contains(rb))
        {
            objectsInRange.Remove(rb);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = !isActive; 
            Debug.Log("Black Hole " + (isActive ? "Activated" : "Deactivated"));
        }
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            foreach (Rigidbody2D rb in objectsInRange)
            {
                if (rb != null)
                {
                    Vector2 direction = (Vector2)transform.position - rb.position;

                    rb.AddForce(direction.normalized * pullForce * Time.fixedDeltaTime);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }
}
