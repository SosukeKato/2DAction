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
    bool _OnGround;

    #region 攻撃のPrefabを保存する変数
    [SerializeField]
    GameObject _NAttack;
    [SerializeField]
    GameObject _OverHeadAttack;
    [SerializeField]
    GameObject _UpperImpulse;
    #endregion

    #region 攻撃の発生位置を管理する変数
    [SerializeField]
    Transform _PlayerFront;
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

    bool _NAttackStartCT;
    bool _OverHeadAttackStartCT;
    bool _UpperImpulseStartCT;
    #endregion

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
        if (Input.GetKeyDown(KeyCode.J) && _NAttackStartCT == false)
        {
            Instantiate(_NAttack,_PlayerFront.position,Quaternion.identity);
            _NAttackStartCT = true;
            _pA.SetTrigger("NAttack");
            StartCoroutine("NAttackCT");
        }
        //頭上に攻撃するスキルの処理
        if (Input.GetKeyDown(KeyCode.I) && _OnGround == true && _OverHeadAttackStartCT == false)
        {
            Instantiate(_OverHeadAttack, _PlayerOverHead.position, Quaternion.identity);
            _OverHeadAttackStartCT = true;
            StartCoroutine("OverHeadAttackSkillCT");
        }
        //頭上にEnemyを打ち上げるスキルの処理
        if (Input.GetKeyDown(KeyCode.M) && _OnGround == true && _UpperImpulseStartCT == false)
        {
            Instantiate(_UpperImpulse, _PlayerFoot.position, Quaternion.identity);
            _UpperImpulseStartCT = true;
            StartCoroutine("UpperImpulseSkillCT");
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
        _OverHeadAttackStartCT = false;
    }

    IEnumerator UpperImpulseSkillCT()
    {
        yield return new WaitForSeconds(_UpperImpulseCT);
        _UpperImpulseStartCT = false;
    }

    IEnumerator NAttackCT()
    {
        yield return new WaitForSeconds(_NAttackCT);
        _NAttackStartCT = false;
    }
    #endregion
}
