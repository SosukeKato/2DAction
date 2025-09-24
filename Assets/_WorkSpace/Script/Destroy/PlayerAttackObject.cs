using System.Collections;
using UnityEngine;

public class PlayerAttackObject : MonoBehaviour
{
    [SerializeField]
    float _attackDuration;
    [SerializeField]
    int _bulletHeal = 15;

    GameObject _playerObj;
    PlayerHealth _pH;

    private void Awake()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _pH = _playerObj.GetComponent<PlayerHealth>();
    }

    IEnumerator Start()
    {
        Application.targetFrameRate = 30;
        yield return new WaitForSeconds(_attackDuration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _pH._playerHealth += _bulletHeal;
        }
    }
}
