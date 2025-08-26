using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool _death;
    [SerializeField]
    int _flyerBulletDamage = 7;
    [SerializeField]
    int _itemHeal = 5;
    [SerializeField]
    public int _playerHealth = 100;

    void Update()
    {
        if(_playerHealth <= 0)
        {
            _death = true;
        }
        else
        {
            _death = false;
        }
        if (_playerHealth >= 100)
        {
            _playerHealth = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FlyerBullet"))
        {
            _playerHealth -= _flyerBulletDamage;
            Debug.Log($"{_playerHealth}");
        }
        if (collision.gameObject.CompareTag("HealItem"))
        {
            _playerHealth += _itemHeal;
            Debug.Log($"{_playerHealth}");
        }
    }
}