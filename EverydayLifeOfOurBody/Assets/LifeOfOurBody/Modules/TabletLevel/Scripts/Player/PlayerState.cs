using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerMove _pm;
    [SerializeField] private Sprite _newSprite;
    [SerializeField] private Vector3 _newSize = new Vector3(1.5f, 1.5f, 1f);
    [SerializeField] private CapsuleCollider2D _capsuleCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out TriggerDoor door))
        {
            _rb.freezeRotation = true;
            _spriteRenderer.sprite = _newSprite;
            transform.localScale = _newSize;
            _pm.enabled = true;
            _capsuleCollider.size = new Vector2(_newSize.x, _newSize.y);
            _capsuleCollider.offset = new Vector2(0, 0);
        }
    }
}
