using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BloodSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private List<Transform> _list = new();

    private bool _isSpawning;
    private float spawnInterval = 8f; 
    private float timeSinceLastSpawn = 0f;

    private const int StartBloodCount = 10;

    private void Start()
    {
        _isSpawning = true;
        for (int i = 0; i < StartBloodCount; i++)
            SpawnBlood();        
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnBlood();
            timeSinceLastSpawn = 0f; 
        }
    }

    private void SpawnBlood()
    {
        if (!_isSpawning) return;
        var unit = Instantiate(Resources.Load("Prefabs/Blood"), _spawnTransform.position, Quaternion.identity);
        unit.GetComponent<UnitSelect>().MoveTo(GetRandomPointInCollider());
    }

    private Vector3 GetRandomPointInCollider()
    {
        return _list[Random.Range(0, _list.Count)].position;
    }
}
