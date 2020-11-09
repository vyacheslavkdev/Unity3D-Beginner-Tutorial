using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _ghost;
    [SerializeField] private Transform _spawn;
    [SerializeField] private int _spawnMaxCount = 5;

    private GameObject _spawnedGhost = null;
    private int _spawnCount = 0;

    void Start()
    {
        if (_spawnedGhost is null)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        _spawnedGhost = Instantiate(_ghost, _spawn.position, _spawn.rotation);
        _spawnCount++;
    }

    void Update()
    {
        if (_spawnCount < _spawnMaxCount && _spawnedGhost is null)
        {
            Spawn();
        }
    }
}
