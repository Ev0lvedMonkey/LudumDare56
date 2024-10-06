using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameObject particalEffect;  // Particle System, ������� ����� �������������
    public Sprite newSprite;           // ����� ������, ������� ����� ����������
    public GameObject player;          // �����
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        // �������������� ������ �� ����������� ����������
        _rb = player.GetComponent<Rigidbody2D>();
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // ���� ����� ����������, ����� ������ ������� �� ��������
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out TriggerDoor door))
        {
            //// ����������� Particle System
            //if (particalEffect != null)
            //{
            //    particalEffect.SetActive(true);
            //}

            // ������ ������
            _spriteRenderer.sprite = newSprite;

            // ������ ������ ������ (localScale)
            player.transform.localScale = new Vector3(0.5f, 0.4f, 1f);

            // ������ ��� Z �� 0
            Quaternion rotation = player.transform.rotation;
            rotation.z = 0f;
            player.transform.rotation = rotation;
            _rb.freezeRotation = true;
        }
    }

}
