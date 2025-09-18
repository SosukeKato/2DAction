using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    int _bossAttackInterval = 10;
    [SerializeField]
    List<GameObject> _bossAttackObj;
    [SerializeField]
    List<Transform> _bossAttackPos;

    float _bossAttackTimer;
    void Start()
    {
        
    }

    void Update()
    {
        _bossAttackTimer += Time.deltaTime;
        if (_bossAttackTimer >= _bossAttackInterval)
        {
            Instantiate(_bossAttackObj[1], _bossAttackPos[1].position, Quaternion.identity);
        }
    }
}
