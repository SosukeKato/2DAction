using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PositionClamp))]
public class FlyerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _flyerAttack;
    [SerializeField]
    Transform _flyer;
    [SerializeField]
    float _flyerAttackInterval = 10;

    GameObject _flyerAttackObject;
    float _flyerAttackTimer;

    Transform _player;
    [SerializeField]
    float _bulletSpeed;
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            throw new NullReferenceException("playerObj is null");
        }
        _player = playerObj.transform;
    }

    void Update()
    {
        #region 自力
        _flyerAttackTimer += Time.deltaTime;
        if (_flyerAttackTimer >= _flyerAttackInterval)
        {
            _flyerAttackTimer = 0;
            _flyerAttackObject = Instantiate(_flyerAttack, _flyer.position, transform.rotation);
        }
        #endregion

        #region AI
        // プレイヤーへの方向を計算
        Vector2 direction = (_player.position - _flyer.position).normalized;

        // 弾にRigidbody2Dがある場合、速度を設定
        Rigidbody2D bulletRb = _flyerAttackObject.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.velocity = direction * _bulletSpeed;
        }

        // 弾の向きを設定（オプション）
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _flyerAttackObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        #endregion
    }
}
