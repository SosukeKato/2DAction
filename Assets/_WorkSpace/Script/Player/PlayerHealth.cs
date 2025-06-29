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
    public int _Health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_Health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        if (_Health >= 100)
        {
            _Health = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FlyerBullet"))
        {
            _Health -= _FlyerBulletDamage;
            Debug.Log($"{_Health}");
        }
        if (collision.gameObject.CompareTag("HealItem"))
        {
            _Health += _ItemHeal;
            Debug.Log($"{_Health}");
        }
    }
}
