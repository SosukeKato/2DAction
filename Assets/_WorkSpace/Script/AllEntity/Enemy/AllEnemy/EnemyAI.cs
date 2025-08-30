using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    public float _MoveSpeed = 3f;
    [SerializeField]
    int _PlayerScale = 3;

    Transform _Player;

    Transform _tr;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr = transform;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            throw new NullReferenceException("playerObj is null");
        }
        _Player = playerObj.transform;
    }

    void Update()
    {
        float _playerX = _Player.position.x;
        float _enemyX = transform.position.x;

        if (_Player == null) return;

        Vector2 direction = new Vector2(_playerX - _enemyX,0f).normalized;
        transform.position += (Vector3)(direction * _MoveSpeed * Time.deltaTime);

        if (_playerX - _enemyX > 0)
        {
            _tr.localScale = new Vector3(_PlayerScale, _PlayerScale, 1);
        }
        if (_playerX - _enemyX < 0)
        {
            _tr.localScale = new Vector3(-_PlayerScale, _PlayerScale, 1);
        }
    }
}
