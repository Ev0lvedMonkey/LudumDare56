using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

public class PlayerMove : MonoBehaviour
{
    public int speedPlayer = 10;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем SpriteRenderer для поворота спрайта
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput * speedPlayer, verticalInput * speedPlayer, 0);
        rb.velocity = moveDirection;

        // Поворот игрока в зависимости от направления по оси X
        if (horizontalInput < 0)  // Движение вправо
        {
            spriteRenderer.flipX = false; // Спрайт не переворачивается
        }
        else if (horizontalInput > 0) // Движение влево
        {
            spriteRenderer.flipX = true; // Переворачиваем спрайт по оси X
        }
        
    }
}
