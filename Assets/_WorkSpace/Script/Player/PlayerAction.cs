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

    #region �U����Prefab��ۑ�����ϐ�
    [SerializeField]
    GameObject _NAttack;
    [SerializeField]
    GameObject _OverHeadAttack;
    [SerializeField]
    GameObject _UpperImpulse;
    #endregion

    #region �U���̔����ʒu���Ǘ�����ϐ�
    [SerializeField]
    Transform _PlayerFront;
    [SerializeField]
    Transform _PlayerOverHead;
    [SerializeField]
    Transform _PlayerFoot;
    #endregion

    #region �U����CT���Ǘ�����ϐ�
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
        #region �L�����N�^�[�̊�{�ړ�����
        //x���̈ړ�����
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {
            _pA.SetBool("Move", true);
        }
        else
        {
            _pA.SetBool("Move", false);
        }
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

        //�ʏ�U���̏���
        if (Input.GetKeyDown(KeyCode.J) && _NAttackStartCT == false)
        {
            Instantiate(_NAttack,_PlayerFront.position,Quaternion.identity);
            _NAttackStartCT = true;
            _pA.SetTrigger("NAttack");
            StartCoroutine("NAttackCT");
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

    #region CT����
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
