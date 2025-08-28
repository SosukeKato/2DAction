using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    PlayerHealth _pH;

    [SerializeField]
    int _itemHeal;
    // Start is called before the first frame update
    void Start()
    {
        _pH = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CatchItem()
    {
        _pH._playerHealth += _itemHeal;
    }
}
