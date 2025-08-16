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
    Transform _playerMuzzle;
    [SerializeField]
    GameObject _playerBullet;
    [SerializeField]
    int _bulletSpeed;
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
    GameObject _bulletAttack;
    Rigidbody2D _rb;
    Transform _tr;
    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x���̈ړ�����
        float x = Input.GetAxisRaw("Horizontal");
        //Player�̌����ڂ�i�s�����ɂ��킹�ĉ�]�����鏈��
        if (x < 0)
        {
            _tr.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (x > 0)
        {
            _tr.eulerAngles = new Vector3(0, 0, 0);
        }
        //�W�����v�̏���
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
        //�ʏ�U���̏���
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(_NAttack,_PlayerFront.position,Quaternion.identity);
        }
        //
        if (Input.GetKeyDown(KeyCode.L))
        {
            _bulletAttack = Instantiate(_playerBullet, _playerMuzzle.position, Quaternion.identity);
            _bulletAttack.GetComponent<Rigidbody>().AddForce(_playerMuzzle.forward * _bulletSpeed);
        }
        //����ɍU������X�L���̏���
        if (Input.GetKeyDown(KeyCode.I) && _OnGround == true && _OverHeadAttackStartCT == false)
        {
            Instantiate(_OverHeadAttack, _PlayerOverHead.position, Quaternion.identity);
            _OverHeadAttackStartCT = true;
            StartCoroutine("OverHeadAttackSkillCT");
        }
        //�����Enemy��ł��グ��X�L���̏���
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

    #region �X�L����CT����
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
