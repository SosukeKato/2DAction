using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(EnemyAI))]
[RequireComponent (typeof(EnemyHealth))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyAttack;
    [SerializeField]
    Transform _enemy;

    GameObject _enemyAttackObject;
    float _enemyAttackInterval;
    void Update()
    {
        _enemyAttackInterval += Time.deltaTime;
        if (_enemyAttackInterval >= 10)
        {
            _enemyAttackObject = Instantiate(_enemyAttack, _enemy.position, Quaternion.identity);
        }
    }
}
