using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    float _MoveSpeed;
    [SerializeField]
    float _JumpPower;
    [SerializeField]
    int _attackSpeed;
    [SerializeField]
    bool _OnGround;

    #region 攻撃のPrefabを保存する変数
    [SerializeField]
    GameObject _NAttack;
    [SerializeField]
    GameObject _OverHeadAttack;
    [SerializeField]
    GameObject _UpperImpulse;
    [SerializeField]
    GameObject _playerBullet;
    #endregion

    #region 攻撃の発生位置を管理する変数
    [SerializeField]
    Transform _playerFront;
    [SerializeField]
    Transform _PlayerOverHead;
    [SerializeField]
    Transform _PlayerFoot;
    #endregion

    #region 攻撃のCTを管理する変数
    [SerializeField]
    int _OverHeadAttackCT;
    [SerializeField]
    int _UpperImpulseCT;
    [SerializeField]
    float _NAttackCT;
    [SerializeField]
    int _playerBulletCT;

    public bool _nAttackStartCT;
    public bool _overHeadAttackStartCT;
    public bool _upperImpulseStartCT;
    public bool _playerBulletStartCT;
    #endregion

    GameObject _bulletobj;

    Animator _pA;

    Rigidbody2D _rb;
    Transform _tr;

    void Start()
    {
        Application.targetFrameRate = 30;
        _tr = transform;
        _rb = GetComponent<Rigidbody2D>();
        _pA = GetComponent<Animator>();
    }


    void Update()
    {
        #region キャラクターの基本移動処理
        //x軸の移動処理
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {
            _pA.SetBool("Move", true);
        }
        else
        {
            _pA.SetBool("Move", false);
        }
        //Playerの見た目を進行方向にあわせて回転させる処理
        if (x < 0)
        {
            _tr.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (x > 0)
        {
            _tr.eulerAngles = new Vector3(0, 0, 0);
        }
        //ジャンプの処理
        if (_OnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _JumpPower);
            _OnGround = false;
            _pA.SetTrigger("Jump");
        }
        if (!_OnGround)
        {
            float gravity = Time.deltaTime * _rb.gravityScale;
            _rb.velocity += Vector2.up * gravity;
        }
        else
        {
            _rb.velocity = Vector2.right * (x * _MoveSpeed);
        }
        #endregion

        //通常攻撃の処理
        if (Input.GetKeyDown(KeyCode.J) && _nAttackStartCT == false)
        {
            Instantiate(_NAttack,_playerFront.position,Quaternion.identity);
            _nAttackStartCT = true;
            _pA.SetTrigger("NAttack");
            StartCoroutine("NAttackCT");
        }
        //頭上に攻撃するスキルの処理
        if (Input.GetKeyDown(KeyCode.I) && _OnGround == true && _overHeadAttackStartCT == false)
        {
            Instantiate(_OverHeadAttack, _PlayerOverHead.position, Quaternion.identity);
            _overHeadAttackStartCT = true;
            StartCoroutine("OverHeadAttackSkillCT");
        }
        //頭上にEnemyを打ち上げるスキルの処理
        if (Input.GetKeyDown(KeyCode.M) && _OnGround == true && _upperImpulseStartCT == false)
        {
            Instantiate(_UpperImpulse, _PlayerFoot.position, Quaternion.identity);
            _upperImpulseStartCT = true;
            StartCoroutine("UpperImpulseSkillCT");
        }
        //Bulletを打ち出すスキルの処理
        if (Input.GetKeyDown(KeyCode.L))
        {
            _bulletobj = Instantiate(_playerBullet, _playerFront.position, Quaternion.identity);
            _bulletobj.GetComponent<Rigidbody>().AddForce(_playerFront.forward * _attackSpeed);  
            _playerBulletStartCT = true;
            StartCoroutine("PlayerBulletSkillCT");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _OnGround = true;
        }
    }

    #region CT処理
    IEnumerator OverHeadAttackSkillCT()
    {
        yield return new WaitForSeconds(_OverHeadAttackCT);
        _overHeadAttackStartCT = false;
    }

    IEnumerator UpperImpulseSkillCT()
    {
        yield return new WaitForSeconds(_UpperImpulseCT);
        _upperImpulseStartCT = false;
    }

    IEnumerator NAttackCT()
    {
        yield return new WaitForSeconds(_NAttackCT);
        _nAttackStartCT = false;
    }

    IEnumerator PlayerBulletSkillCT()
    {
        yield return new WaitForSeconds(_playerBulletCT);
        _playerBulletStartCT = false;
    }
    #endregion
}
