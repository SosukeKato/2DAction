using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    PlayerHealth _pH;

    [SerializeField]
    int _itemHeal;
    void Start()
    {
        _pH = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CatchItem();
        }
    }

    public override void CatchItem()
    {
        _pH._playerHealth += _itemHeal;
    }
}
