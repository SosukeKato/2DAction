using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool _death;
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
}