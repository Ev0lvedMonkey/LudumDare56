using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleStomatch : MonoBehaviour
{
    public float pullForce = 20f; // Сила притяжения
    public float pullRadius = 5f; // Радиус, в котором объекты притягиваются

    private List<Rigidbody2D> objectsInRange = new List<Rigidbody2D>(); // Список объектов внутри радиуса
    private bool isActive = false; // Состояние Black Hole (активен или нет)

    // Метод вызывается, когда объект попадает в область триггера
    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, есть ли у объекта Rigidbody2D для притягивания
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Добавляем объект в список притягиваемых объектов
            objectsInRange.Add(rb);
        }
    }

    // Метод вызывается, когда объект выходит из области триггера
    void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null && objectsInRange.Contains(rb))
        {
            // Убираем объект из списка, когда он выходит из радиуса
            objectsInRange.Remove(rb);
        }
    }

    void Update()
    {
        // Включение/выключение Black Hole по нажатию пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = !isActive; // Переключаем состояние Black Hole
            Debug.Log("Black Hole " + (isActive ? "Activated" : "Deactivated"));
        }
    }

    void FixedUpdate()
    {
        // Притягиваем объекты только если Black Hole активен
        if (isActive)
        {
            foreach (Rigidbody2D rb in objectsInRange)
            {
                if (rb != null)
                {
                    // Рассчитываем направление от объекта к центру Black Hole
                    Vector2 direction = (Vector2)transform.position - rb.position;

                    // Применяем силу притяжения к объекту
                    rb.AddForce(direction.normalized * pullForce * Time.fixedDeltaTime);
                }
            }
        }
    }

    // Для визуализации радиуса в сцене
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }
}
