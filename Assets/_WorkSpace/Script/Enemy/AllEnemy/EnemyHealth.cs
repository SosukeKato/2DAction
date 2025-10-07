using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    GameObject _playerObj;
    PlayerHealth _pH;
    EnemyAI _EAI;
    Rigidbody2D _rb;
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
    GameObject _enemyDropItem = null;

    int _randomItemDrop;

    void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        Application.targetFrameRate = 30;
        _rb = GetComponent<Rigidbody2D>();
        _EAI = GetComponent<EnemyAI>();
        _pH = _playerObj.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
            Instantiate(_enemyDropItem, transform.position, Quaternion.identity);
        }
        if (_health >= _MaxHealth)
        {
            _health = _MaxHealth;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _OnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)//collisionは引数だから名前変えても動くお
    {
        if (collision.gameObject.CompareTag("Ground"))
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
            _pH._playerHealth += _playerBulletDamage;
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
