using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int _playerHealth = 100;
    [SerializeField]
    int _heal = 3;
    [SerializeField]
    int _flyerAttackDamage = 5;

    void Update()
    {
        if(_playerHealth <= 0)
        {
            
        }
        if (_playerHealth >= 100)
        {
            _playerHealth = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region �A�C�e���擾���̏���
        if (collision.CompareTag("HealItem"))
        {
            _playerHealth += _heal;
            Debug.Log($"����HP��{_playerHealth}�����");
        }
        #endregion

        #region Player���_���[�W��H�炤����
        if (collision.CompareTag("FlyerBullet"))
        {
            _playerHealth -= _flyerAttackDamage;
            Debug.Log($"����HP��{_playerHealth}�����");
        }
        #endregion
    }
}