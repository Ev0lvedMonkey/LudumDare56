using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;
    }
}
