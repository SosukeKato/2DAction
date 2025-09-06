using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    public float _MoveSpeed = 3f;
    [SerializeField]
    int _PlayerScale = 3;
    [SerializeField]
    float _stopDistance = 1;

    Animator _sA;

    Transform _Player;

    Transform _tr;
    Rigidbody2D _rb;
    void Start()
    {
        Application.targetFrameRate = 30;

        _rb = GetComponent<Rigidbody2D>();
        _tr = transform;
        _sA = GetComponent<Animator>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            throw new NullReferenceException("playerObj is null");
        }
        _Player = playerObj.transform;
    }

    void Update()
    {
        if (_Player == null) return;

        float _playerX = _Player.position.x;
        float _enemyX = transform.position.x;
        float _distance = Mathf.Abs(_playerX - _enemyX);//(AI)

        if (_distance > _stopDistance) //‹——£‚ðŽæ“¾‚µ‚Ä‚»‚Ì‹——£‚æ‚è‹ß‚Ã‚©‚È‚¢‚æ‚¤‚É‚·‚éðŒ•¶(AI)
        {
            Vector2 direction = new Vector2(_playerX - _enemyX, 0f).normalized;
            transform.position += (Vector3)(direction * _MoveSpeed * Time.deltaTime);
            _sA.SetBool("SkeltonMove", true);
        }
        else
        {
            _sA.SetBool("SkeltonMove", false);
        }

        if (_playerX - _enemyX > 0)
        {
            _tr.eulerAngles = new Vector3(0, 0, 0);
        }
        if (_playerX - _enemyX < 0)
        {
            _tr.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}

