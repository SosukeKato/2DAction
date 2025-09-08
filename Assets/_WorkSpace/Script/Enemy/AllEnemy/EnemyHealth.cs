using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyAI _EAI;
    Rigidbody2D _rb;
    bool _Death;
    bool _OnGround;
    [SerializeField]
    int _Health = 100;
    [SerializeField]
    int _MaxHealth = 100;
    [SerializeField]
    int _NAttackDamage = 15;
    [SerializeField]
    int _OverHeadAttackDamage = 30;
    [SerializeField]
    int _AirEnemyDefenseDebuff = 2;
    [SerializeField]
    float _JumpPower = 30;
    [SerializeField]
    List<GameObject> _EnemyDropItem = null;

    void Start()
    {
        Application.targetFrameRate = 30;
        _rb = GetComponent<Rigidbody2D>();
        _EAI = GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (_Health <= 0)
        {
            _Death = true;
        }
        else
        {
            _Death = false;
        }
        if (_Health >= _MaxHealth)
        {
            _Health = _MaxHealth;
        }
        if (_Death == true)
        {
            Destroy(gameObject);
            int RandomItemDrop = Random.Range(0, _EnemyDropItem.Count);
            Instantiate(_EnemyDropItem[RandomItemDrop], transform.position, Quaternion.identity);
        }
        if (_OnGround == true)
        {
            _AirEnemyDefenseDebuff = 1;
        }
        else
        {
            _AirEnemyDefenseDebuff = 2;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            _OnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)//collisionà¯êîÇæÇ©ÇÁñºëOïœÇ¶ÇƒÇ‡ìÆÇ≠Ç®
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
            _Health -= _NAttackDamage * _AirEnemyDefenseDebuff;
            Debug.Log($"Ç±ÇÃìGÇÃHPÇÕ{_Health}Ç∂Ç·ÇÊ");
        }
        if (collision.gameObject.CompareTag("OverHeadAttack"))
        {
            _Health -= _OverHeadAttackDamage * _AirEnemyDefenseDebuff;
            Debug.Log($"Ç±ÇÃìGÇÃHPÇÕ{_Health}Ç∂Ç·ÇÊ");
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
