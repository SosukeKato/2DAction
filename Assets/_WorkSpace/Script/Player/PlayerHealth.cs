using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int _FlyerBulletDamage = 7;
    [SerializeField]
    int _ItemHeal = 5;
    [SerializeField]
    public int _PlayerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_PlayerHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        if (_PlayerHealth >= 100)
        {
            _PlayerHealth = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FlyerBullet"))
        {
            _PlayerHealth -= _FlyerBulletDamage;
            Debug.Log($"{_PlayerHealth}");
        }
        if (collision.gameObject.CompareTag("HealItem"))
        {
            _PlayerHealth += _ItemHeal;
            Debug.Log($"{_PlayerHealth}");
        }
    }
}