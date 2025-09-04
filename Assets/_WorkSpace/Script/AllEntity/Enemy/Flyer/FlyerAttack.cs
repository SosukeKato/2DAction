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

    GameObject _flyerAttackObject;
    float _flyerAttackInterval;

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
        #region ����
        _flyerAttackInterval += Time.deltaTime;
        if (_flyerAttackInterval >= 10)
        {
            _flyerAttackInterval = 0;
            _flyerAttackObject = Instantiate(_flyerAttack, _flyer.position, transform.rotation);
        }
        #endregion

        #region AI
        // �v���C���[�ւ̕������v�Z
        Vector2 direction = (_player.position - _flyer.position).normalized;

        // �e��Rigidbody2D������ꍇ�A���x��ݒ�
        Rigidbody2D bulletRb = _flyerAttackObject.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.velocity = direction * _bulletSpeed;
        }

        // �e�̌�����ݒ�i�I�v�V�����j
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _flyerAttackObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        #endregion
    }
}
