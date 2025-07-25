using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerBaseAction : MonoBehaviour
{
    [SerializeField]
    float _MoveSpeed;
    [SerializeField]
    float _JumpPower;
    [SerializeField]
    GameObject _NAttack;
    [SerializeField]
    GameObject _OverHeadAttack;
    [SerializeField]
    GameObject _UpperImpulse;
    [SerializeField]
    Transform _PlayerFront;
    [SerializeField]
    Transform _PlayerOverHead;
    [SerializeField]
    Transform _PlayerFoot;
    [SerializeField]
    int _OverHeadAttackCT;
    [SerializeField]
    int _UpperImpulseCT;
    [SerializeField]
    bool _OverHeadAttackStartCT;
    [SerializeField]
    bool _UpperImpulseStartCT;
    [SerializeField]
    bool _OnGround;
    int _LeftShiftNumber = 0;
    public Rigidbody2D _rb;
    public Transform _tr;
    Vector3 SavePosition = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
        _rb = GetComponent<Rigidbody2D>();
        SavePosition = _tr.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //x軸の移動処理
        float x = Input.GetAxisRaw("Horizontal");
        //Playerの見た目を進行方向にあわせて回転させる処理
        if (x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //ジャンプの処理
        if (_OnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _JumpPower);
            _OnGround = false;
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
        //通常攻撃の処理
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(_NAttack,_PlayerFront.position,Quaternion.identity);
        }
        //保存した位置に帰ってくるスキルの処理
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _LeftShiftNumber += 1;
            if (_LeftShiftNumber % 2 == 1)
            {
                SavePosition = _tr.position; 
            }
            else if (_LeftShiftNumber % 2 == 0)
            {
                _tr.position = SavePosition;
            }
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

    #region スキルのCT処理
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
    #endregion
}
