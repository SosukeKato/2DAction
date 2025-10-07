using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform _tr;

    [SerializeField]
    int _bossAttackInterval = 10;
    [SerializeField]
    GameObject[] _bossAttackObj;
    [SerializeField]
    Transform[] _bossAttackPos;

    Transform _player;
    GameObject _playerObj;

    float _playerX;
    float _bossX;

    float _bossAttackTimer;
    int _randomBossAttack;
    int _randomBossAttackPos;
    void Start()
    {
        _tr = transform;

        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _player = _playerObj.transform;
    }

    void Update()
    {
        _playerX = _player.position.x;
        _bossX = _tr.position.x;
        #region BossÇÃçUåÇèàóù
        _bossAttackTimer += Time.deltaTime;
        if (_bossAttackTimer >= _bossAttackInterval)
        {
            _bossAttackTimer = 0;
            switch(Random.Range(0,1))
            {
                case 0:
                    _randomBossAttack = Random.Range(0, _bossAttackObj.Length);
                    _randomBossAttackPos = Random.Range(0, _bossAttackPos.Length);
                    Instantiate(_bossAttackObj[_randomBossAttack], _bossAttackPos[_randomBossAttackPos].position, Quaternion.identity);
                    break;
                case 1:
                    _bossX *= -1;
                    break;
            }
        }
        #endregion

        #region BossÇÃç∂âEÇÃå©ÇΩñ⁄ÇÃí≤êÆ
        if (_playerX - _bossX < 0)
        {
            _tr.eulerAngles = new Vector3(0, 0, 0);
        }
        if (_playerX - _bossX > 0)
        {
            _tr.eulerAngles = new Vector3(0, 180, 0);
        }
        #endregion
    }
}
