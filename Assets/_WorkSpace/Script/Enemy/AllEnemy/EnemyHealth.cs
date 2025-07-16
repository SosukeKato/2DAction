using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyHealth : MonoBehaviour
{
    bool _Death;
    bool _OnGround;
    [SerializeField]
    int _Health = 100;
    [SerializeField]
    int _MaxHealth = 100;
    [SerializeField]
    int _NAttackDamage = 15;
    [SerializeField]
    int _AirEnemyDefenseDebuff = 2;
    [SerializeField]
    List<GameObject> _EnemyDropItem = null; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            int RandomItemDrop = UnityEngine.Random.Range(0, _EnemyDropItem.Count);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _OnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _OnGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("NAttack"))
        {
            _Health -= _NAttackDamage * _AirEnemyDefenseDebuff;
            Debug.Log($"‚±‚Ì“G‚ÌHP‚Í{_Health}‚¶‚á‚æ");
        }
    }
}
