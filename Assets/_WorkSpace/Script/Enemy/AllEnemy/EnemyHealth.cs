using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyHealth : MonoBehaviour
{
    bool _Death;
    [SerializeField]
    int _Health = 100;
    [SerializeField]
    int _MaxHealth = 100;
    [SerializeField]
    int _NAttackDamage = 15;
    [SerializeField]
    List<GameObject> _EnemyDropItem; 
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("NAttack"))
        {
            _Health -= _NAttackDamage;
        }
    }
}
