using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BloodSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private List<Transform> _list = new();

    private bool _isSpawning;
    private float spawnInterval = 4f;
    private float timeSinceLastSpawn = 0f;

    private const int StartBloodCount = 4;  
    private const int AfterBloodCount = 2;  
    private const int MaxBloodCount = 20;   
    private int currentBloodCount = 0;      

    [Inject]
    private DiContainer _container;

    private void Update()
    {
        if (!_isSpawning)
            return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval && currentBloodCount < MaxBloodCount)
        {
            for (int i = 0; i < AfterBloodCount; i++)
                SpawnBlood();
            timeSinceLastSpawn = 0f;
        }
    }

    public void StartGame()
    {
        SpanwOn();
        SpawnManyBlood(StartBloodCount);
    }

    public void SpanwOn()
    {
        _isSpawning = true;
    }

    public void SpawnManyBlood(int countOfBlood)
    {
        for (int i = 0; i < countOfBlood; i++)
            SpawnBlood();
    }

    private void SpawnBlood()
    {
        if (!_isSpawning || currentBloodCount >= MaxBloodCount) return;

        var unit = 
            _container.InstantiatePrefab(Resources.Load("Prefabs/Blood"),
            _spawnTransform.position, Quaternion.identity, transform);
        unit.GetComponent<UnitSelect>().MoveTo(GetRandomPointInCollider());

        currentBloodCount++; 
    }

    private Vector3 GetRandomPointInCollider()
    {
        return _list[Random.Range(0, _list.Count)].position;
    }
}
