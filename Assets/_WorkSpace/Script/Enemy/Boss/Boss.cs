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
        #region BossÇÃçUåÇèàóù
        _bossAttackTimer += Time.deltaTime;
        if (_bossAttackTimer >= _bossAttackInterval)
        {
            _randomBossAttack = Random.Range(0, _bossAttackObj.Length);
            _randomBossAttackPos = Random.Range(0, _bossAttackPos.Length);
            Instantiate(_bossAttackObj[_randomBossAttack], _bossAttackPos[_randomBossAttackPos].position, Quaternion.identity);
            _bossAttackTimer = 0;
        }
        #endregion

        #region BossÇÃç∂âEÇÃå©ÇΩñ⁄ÇÃí≤êÆ
        _playerX = _player.position.x;
        _bossX = _tr.position.x;

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
