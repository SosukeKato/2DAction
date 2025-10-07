using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _EnemyPrefab;
    [SerializeField]
    List<Transform> _EnemySpawn;
    [SerializeField]
    GameObject _Boss;
    [SerializeField]
    Transform _BossSpawn;
    [SerializeField]
    float _SpawnInterval;
    [SerializeField]
    int _bossSpawnTime;

    int Random;
    int RandomEnemy;

    float _spawnTimer = 0;
    float _bossSpaenTimer = 0;
    void Start()
    {
        
    }
    void Update()
    {
        _spawnTimer += Time.deltaTime;
        _bossSpaenTimer += Time.deltaTime;

        if (_spawnTimer >= _SpawnInterval)
        {
            Random = UnityEngine.Random.Range(0, _EnemySpawn.Count);
            RandomEnemy = UnityEngine.Random.Range(0, _EnemyPrefab.Count);
            Instantiate(_EnemyPrefab[RandomEnemy], _EnemySpawn[Random].position, Quaternion.identity);
            _spawnTimer = 0f;
        }
        if (_bossSpaenTimer >= _bossSpawnTime)
        {
            Instantiate(_Boss, _BossSpawn.position, Quaternion.identity);
        }
    }
}
