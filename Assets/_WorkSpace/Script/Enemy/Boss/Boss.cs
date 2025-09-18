using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    int _bossAttackInterval = 10;
    [SerializeField]
    GameObject[] _bossAttackObj;
    [SerializeField]
    Transform[] _bossAttackPos;

    float _bossAttackTimer;
    int _randomBossAttack;
    int _randomBossAttackPos;
    void Start()
    {
        
    }

    void Update()
    {
        _bossAttackTimer += Time.deltaTime;
        if (_bossAttackTimer >= _bossAttackInterval)
        {
            _randomBossAttack = Random.Range(0, _bossAttackObj.Length);
            _randomBossAttackPos = Random.Range(0, _bossAttackPos.Length);
            Instantiate(_bossAttackObj[_randomBossAttack], _bossAttackPos[_randomBossAttackPos].position, Quaternion.identity);
        }
    }
}
