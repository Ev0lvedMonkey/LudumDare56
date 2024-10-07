using UnityEngine;
using System.Collections.Generic;
using System;

public class IsEnemy : MonoBehaviour
{
    [SerializeField] private float shrinkSpeed = 0.001f;
    [SerializeField] private TimerScoreController _timerScoreController;

    private Transform _enemyTransform;
    private List<GameObject> collidingObjects = new();

    private void Start()
    {
        _enemyTransform = transform;
    }

    private void Update()
    {
        if (collidingObjects.Count > 0)
        {
            Vector3 currentScale = _enemyTransform.localScale;
            currentScale.x -= shrinkSpeed * Time.deltaTime;
            currentScale.y -= shrinkSpeed * Time.deltaTime;

            _enemyTransform.localScale = currentScale;

            if (currentScale.x <= 0.15f)
            {
                Destroy(gameObject);
                DestroyAllColliders();
            }
        }
    }

    private void DestroyAllColliders()
    {
        foreach (var collider in collidingObjects)
            collider.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<UnitSelect>(out _)
            && !collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Add(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        collidingObjects.Clear();
        _timerScoreController.RemoveEnemy();
    }
}
