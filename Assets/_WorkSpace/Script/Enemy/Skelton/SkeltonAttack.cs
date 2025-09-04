using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _skeltonAttack;
    [SerializeField]
    Transform _skeltonForward;
    [SerializeField]
    float _skeltonAttackInterval;

    float _skeltonAttackTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _skeltonAttackTimer += Time.deltaTime;
        if (_skeltonAttackTimer >= _skeltonAttackInterval)
        {
            _skeltonAttackTimer = 0;
            Instantiate(_skeltonAttack, _skeltonForward.position, Quaternion.identity);
        }
    }
}
