using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionGroup))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private uint _maxPrefabs;
    [SerializeField] private float _timeBetweenSpawn;

    private List<DisablePoolAdder>  _poolFalseActive = new List<DisablePoolAdder>();
    private Transform[] _positions;
    private float _startTime;
    private int _prefabsCount = 0;

    private void Start()
    {
        _startTime = _timeBetweenSpawn;
        _positions = GetComponent<PositionGroup>().GetTransforms;
    }

    private void Update()
    {
        if (CheckLeftTime())
            DoSpawn();
    }

    private bool CheckLeftTime()
    {
        if ((_timeBetweenSpawn -= Time.deltaTime) < 0)
        {
            _timeBetweenSpawn = _startTime;
            return true;
        }
        return false;
    }

    private void DoSpawn()
    {
        if (_maxPrefabs <= _prefabsCount)
        {
            SpawnByDisablePool();
            return;
        }
        SpawnByPrefabInstantiate();
        _prefabsCount++;
    }

    private void SpawnByPrefabInstantiate()
    {
        Instantiate
            (_prefabs[Random.Range(0, _prefabs.Length)],
            _positions[Random.Range(0, _positions.Length)].position,
            Quaternion.identity, transform)
            .TryGetComponent<DisablePoolAdder>(out DisablePoolAdder asteroid);
        asteroid.Init(_poolFalseActive);
    }

    private void SpawnByDisablePool()
    {
        if (_poolFalseActive.Count == 0)
            return;

        DisablePoolAdder asteroid = _poolFalseActive[Random.Range(0, _poolFalseActive.Count)];
        asteroid.transform.position = _positions[Random.Range(0, _positions.Length)].position;
        asteroid.gameObject.SetActive(true);
        _poolFalseActive.Remove(asteroid);
    }
}