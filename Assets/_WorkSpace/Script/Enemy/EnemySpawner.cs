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
    int _BossSpawnCount;

    int Random;
    int RandomEnemy;

    float _SpawnTimer = 0;
    void Start()
    {
        
    }
    void Update()
    {
        _SpawnTimer += Time.deltaTime;

        if (_SpawnTimer >= _SpawnInterval)
        {
            Random = UnityEngine.Random.Range(0, _EnemySpawn.Count);
            RandomEnemy = UnityEngine.Random.Range(0, _EnemyPrefab.Count);
            Instantiate(_EnemyPrefab[RandomEnemy], _EnemySpawn[Random].position, Quaternion.identity);
            _SpawnTimer = 0f;
        }
    }
}
