using System.Collections;
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
    float _SpawnTimer;
    [SerializeField]
    int _BossSpawnCount;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(_BossSpawnCount);
        Instantiate(_Boss, _BossSpawn.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        _SpawnTimer += Time.deltaTime;

        if (_SpawnTimer >= _SpawnInterval)
        {
            int Random = UnityEngine.Random.Range(0, _EnemySpawn.Count);
            int RandomEnemy = UnityEngine.Random.Range(0, _EnemyPrefab.Count);
            Instantiate(_EnemyPrefab[RandomEnemy], _EnemySpawn[Random].position, Quaternion.identity);
            _SpawnTimer = 0f;
        }
    }
}
