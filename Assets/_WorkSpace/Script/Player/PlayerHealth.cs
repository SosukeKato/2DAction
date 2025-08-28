using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool _death;
    int _playerHealth = 100;
    [SerializeField]
    int _heal = 3;

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
        if (collision.CompareTag("HealItem"))
        {
            _playerHealth += _heal;
        }
    }
}