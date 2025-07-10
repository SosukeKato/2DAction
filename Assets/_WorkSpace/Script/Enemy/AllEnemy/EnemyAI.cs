using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    float _MoveSpeed = 3f;

    Transform _Player;
    // Start is called before the first frame update
    void Start()
    {
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
        float _EnemyX = transform.localPosition.x;

        if (_Player == null) return;

        Vector2 direction = (_Player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * _MoveSpeed * Time.deltaTime);

        if (_PlayerX - _EnemyX > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (_PlayerX - _EnemyX < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
