using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    int _bossAttackInterval = 10;

    float _bossAttackTimer;
    void Start()
    {
        
    }

    void Update()
    {
        _bossAttackTimer += Time.deltaTime;
        if (_bossAttackTimer >= _bossAttackInterval)
        {
            
        }
    }
}
