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
    float _flyerAttackDuration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _flyerAttackDuration += Time.deltaTime;
        if (_flyerAttackDuration >= 10)
        {
            _enemyAttackObject = Instantiate(_enemyAttack, _enemy.position, Quaternion.identity);
        }
    }
}
