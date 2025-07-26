using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    float _MoveSpeed = 3f;
    [SerializeField]
    int _PlayerScale = 3;

    Transform _Player;

    Transform _tr;
    Rigidbody2D _rb;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        float _PlayerX = _Player.position.x;
        float _EnemyX = transform.position.x;

        if (_Player == null) return;

        Vector2 direction = (_Player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * _MoveSpeed * Time.deltaTime);

        if (_PlayerX - _EnemyX > 0)
        {
            _tr.localScale = new Vector3(_PlayerScale, _PlayerScale, 1);
        }
        if (_PlayerX - _EnemyX < 0)
        {
            _tr.localScale = new Vector3(-_PlayerScale, _PlayerScale, 1);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {

    //    }
    //}
}
