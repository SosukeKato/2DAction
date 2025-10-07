using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool _death;
    public float _playerHealth = 100;
    [SerializeField]
    int _heal = 3;
    [SerializeField]
    int _flyerAttackDamage = 5;
    [SerializeField]
    int _skeltonAttackDamage = 7;

    void Update()
    {
        if(_playerHealth <= 0)
        {
            _death = true;
        }
        if (_playerHealth >= 100)
        {
            _playerHealth = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region アイテム取得時の処理
        if (collision.CompareTag("HealItem"))
        {
            _playerHealth += _heal;
            Destroy(collision.gameObject);
        }
        #endregion

        #region Playerがダメージを食らう処理
        if (collision.CompareTag("FlyerBullet"))
        {
            _playerHealth -= _flyerAttackDamage;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("SkeltonAttack"))
        {
            _playerHealth -= _skeltonAttackDamage;
            Destroy(collision.gameObject);
        }
        #endregion
    }
}