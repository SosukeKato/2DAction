using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(EnemyAI))]
[RequireComponent (typeof(EnemyHealth))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
[RequireComponent (typeof(PositionClamp))]
public class FlyerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _flyerAttack;
    [SerializeField]
    Transform _flyer;

    GameObject _flyerAttackObject;
    float _flyerAttackInterval;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        _flyerAttackInterval += Time.deltaTime;
        if (_flyerAttackInterval >= 10)
        {
            _flyerAttackInterval = 0;
            _flyerAttackObject = Instantiate(_flyerAttack, _flyer.position, transform.rotation);
        }
    }
}
