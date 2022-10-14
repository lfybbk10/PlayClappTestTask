using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider _spawnZoneCollider;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _poolContainer;
    
    [SerializeField] private float _spawnInterval;
    
    private float _spawnTimer;

    private void Start()
    {
        PoolManager.WarmPool(_cubePrefab, 10,_poolContainer);
        SpawnCube();
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer > _spawnInterval)
        {
            _spawnTimer = 0;
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        PoolManager.SpawnObject(_cubePrefab, GetRandomPoint(), Quaternion.identity);
    }

    private Vector3 GetRandomPoint()
    {
        float minX = _spawnZoneCollider.bounds.min.x;
        float minZ = _spawnZoneCollider.bounds.min.z;
        float maxX = _spawnZoneCollider.bounds.max.x;
        float maxZ = _spawnZoneCollider.bounds.max.z;

        return new Vector3(Random.Range(minX, maxX), 0,Random.Range(minZ, maxZ));
    }
}
