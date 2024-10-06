using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFood : MonoBehaviour
{
    [SerializeField] private float growFactor = 1.1f; // Коэффициент увеличения размера
    private CircleCollider2D _collider;
    private float _playerSize;

    private void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        _playerSize = transform.localScale.x; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IsFood food))
        {
            float foodSize = collision.transform.localScale.x; 

            if (foodSize < _playerSize)
            {
                Eat(collision.gameObject);
                Debug.Log("Eated");
            }
            else
                Debug.Log($"not Eated\n{foodSize}  {_playerSize}");
        }
    }

    private void Eat(GameObject food)
    {
        _playerSize *= growFactor;
        transform.localScale = new Vector3(_playerSize, _playerSize, 1); 

        Destroy(food); 
    }
}
