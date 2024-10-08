using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BloodSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private List<Transform> _list = new();
    [SerializeField] private bool _spawnBlood = true;
    [SerializeField] private GameObject _mackObj;
    [SerializeField] private MenuPauseController _menuPauseController;

    private bool _isSpawning;
    private float timeSinceLastSpawn = 0f;

    [SerializeField] private float spawnInterval = 4f;
    [SerializeField] private int StartBloodCount = 4;
    [SerializeField] private int AfterBloodCount = 2;
    [SerializeField] private int MaxBloodCount = 20;
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
                SpawnUnit();
            timeSinceLastSpawn = 0f;
        }

        if (AreAllUnitsDeactivated())
        {
            _menuPauseController.OpenMenu(MenuPauseController.MenuStatus.Lose);
        }
    }

    public void StartGame()
    {
        SpanwOn();
        SpawnManyUnits(StartBloodCount);
        _menuPauseController.gameObject.SetActive(true);
    }

    public void SpanwOn()
    {
        _isSpawning = true;
    }

    public void SpawnManyUnits(int count)
    {
        for (int i = 0; i < count; i++)
            SpawnUnit();
    }

    private void SpawnUnit()
    {
        if (!_isSpawning || currentBloodCount >= MaxBloodCount) return;

        if (_spawnBlood)
        {
            var unit = _container.InstantiatePrefab(Resources.Load("Prefabs/Blood"), _spawnTransform.position, Quaternion.identity, transform);
            unit.GetComponent<UnitSelect>().MoveTo(GetRandomPointInCollider());
        }
        else
        {
            var unit = _container.InstantiatePrefab(_mackObj, _spawnTransform.position, Quaternion.identity, transform);
            unit.GetComponent<UnitSelect>().MoveTo(GetRandomPointInCollider());
        }
        currentBloodCount++;
    }

    private bool AreAllUnitsDeactivated()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.activeSelf)
                return false;
        }
        return true;
    }

    private Vector3 GetRandomPointInCollider()
    {
        return _list[Random.Range(0, _list.Count)].position;
    }
}
