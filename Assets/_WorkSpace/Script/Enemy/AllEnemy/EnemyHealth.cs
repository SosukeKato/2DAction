using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyAI _EAI;
    Rigidbody2D _rb;
    bool _death;
    bool _OnGround;
    [SerializeField]
    int _health = 100;
    [SerializeField]
    int _MaxHealth = 100;
    #region ダメージを管理する変数
    [SerializeField]
    int _nAttackDamage = 15;
    [SerializeField]
    int _overHeadAttackDamage = 30;
    [SerializeField]
    int _playerBulletDamage;
    [SerializeField]
    int _airEnemyDefenseDebuff = 2;
    [SerializeField]
    float _JumpPower = 30;
    #endregion
    [SerializeField]
    List<GameObject> _enemyDropItem = null;

    int _randomItemDrop;

    void Start()
    {
        Application.targetFrameRate = 30;
        _rb = GetComponent<Rigidbody2D>();
        _EAI = GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (_health <= 0)
        {
            _death = true;
        }
        else
        {
            _death = false;
        }
        if (_health >= _MaxHealth)
        {
            _health = _MaxHealth;
        }
        if (_death == true)
        {
            Destroy(gameObject);
            _randomItemDrop = Random.Range(0, _enemyDropItem.Count);
            Instantiate(_enemyDropItem[_randomItemDrop], transform.position, Quaternion.identity);
        }
        if (_OnGround == true)
        {
            _airEnemyDefenseDebuff = 1;
        }
        else
        {
            _airEnemyDefenseDebuff = 2;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            _OnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)//collisionは引数だから名前変えても動くお
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _OnGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("NAttack"))
        {
            _health -= _nAttackDamage * _airEnemyDefenseDebuff;
        }
        if (collision.gameObject.CompareTag("OverHeadAttack"))
        {
            _health -= _overHeadAttackDamage * _airEnemyDefenseDebuff;
        }
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            _health -= _playerBulletDamage;
        }
        if (collision.gameObject.CompareTag("UpperImpulse"))
        {
            if (_OnGround == true)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _JumpPower);
                _OnGround = false;
            }
            if (!_OnGround)
            {
                float gravity = Time.deltaTime * _rb.gravityScale;
                _rb.velocity += Vector2.up * gravity;
            }
            else
            {
                _rb.velocity = Vector2.right * (_EAI._MoveSpeed);
            }
        }
    }
}
