using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameObject particalEffect;  // Particle System, который будет проигрываться
    public Sprite newSprite;           // Новый спрайт, который нужно установить
    public GameObject player;          // Игрок
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        // Инициализируем ссылки на необходимые компоненты
        _rb = player.GetComponent<Rigidbody2D>();
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Этот метод вызывается, когда объект выходит из триггера
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out TriggerDoor door))
        {
            //// Проигрываем Particle System
            //if (particalEffect != null)
            //{
            //    particalEffect.SetActive(true);
            //}

            // Меняем спрайт
            _spriteRenderer.sprite = newSprite;

            // Меняем размер игрока (localScale)
            player.transform.localScale = new Vector3(0.5f, 0.4f, 1f);

            // Меняем ось Z на 0
            Quaternion rotation = player.transform.rotation;
            rotation.z = 0f;
            player.transform.rotation = rotation;
            _rb.freezeRotation = true;
        }
    }

}
