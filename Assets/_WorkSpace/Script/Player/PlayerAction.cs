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
    int _bulletSpeed;
    [SerializeField]
    bool _OnGround;

    #region �U����Prefab��ۑ�����ϐ�
    [SerializeField]
    GameObject _NAttack;
    [SerializeField]
    GameObject _OverHeadAttack;
    [SerializeField]
    GameObject _UpperImpulse;
    [SerializeField]
    GameObject _playerBullet;
    #endregion

    #region �U���̔����ʒu���Ǘ�����ϐ�
    [SerializeField]
    Transform _playerFront;
    [SerializeField]
    Transform _PlayerOverHead;
    [SerializeField]
    Transform _PlayerFoot;
    #endregion

    #region �U����CT���Ǘ�����ϐ�
    [SerializeField]
    public float _overHeadAttackCT = 4;
    [SerializeField]
    public float _upperImpulseCT = 5;
    [SerializeField]
    float _nAttackCT;
    [SerializeField]
    public float _playerBulletCT = 12;

    public float _oHAElapsedTime;
    public float _uIElapsedTime;
    public float _nAElapsedTime;
    public float _pBElapsedTime;

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
        if (Input.GetKeyDown(KeyCode.J) && _nAttackStartCT == false)
        {
            Instantiate(_NAttack,_playerFront.position,Quaternion.identity);
            _pA.SetTrigger("NAttack");
            _nAttackStartCT = true;
        }
        if (_nAttackStartCT == true)
        {
            _nAElapsedTime += Time.deltaTime;
            if(_nAElapsedTime > _nAttackCT)
            {
                _nAttackStartCT = false;
                _nAElapsedTime = 0;
            }
        }
        //����ɍU������X�L���̏���
        if (Input.GetKeyDown(KeyCode.I) && _OnGround == true && _overHeadAttackStartCT == false)
        {
            Instantiate(_OverHeadAttack, _PlayerOverHead.position, Quaternion.identity);
            _overHeadAttackStartCT = true;
        }
        if (_overHeadAttackStartCT == true)
        {
            _oHAElapsedTime += Time.deltaTime;
            if(_oHAElapsedTime > _overHeadAttackCT)
            {
                _overHeadAttackStartCT = false;
                _oHAElapsedTime = 0;
            }
        }
        //�����Enemy��ł��グ��X�L���̏���
        if (Input.GetKeyDown(KeyCode.M) && _OnGround == true && _upperImpulseStartCT == false)
        {
            Instantiate(_UpperImpulse, _PlayerFoot.position, Quaternion.identity);
            _upperImpulseStartCT = true;
        }
        if (_upperImpulseStartCT == true)
        {
            _uIElapsedTime += Time.deltaTime;
            if(_uIElapsedTime > _upperImpulseCT)
            {
                _upperImpulseStartCT = false;
                _uIElapsedTime = 0;
            }
        }
        //Bullet��ł��o���X�L���̏���
        if (Input.GetKeyDown(KeyCode.L))
        {
            _bulletobj = Instantiate(_playerBullet, _playerFront.position, Quaternion.identity);
            _bulletobj.GetComponent<Rigidbody2D>().AddForce(_playerFront.right * _bulletSpeed);  
            _playerBulletStartCT = true;
        }
        if (_playerBulletStartCT == true)
        {
            _pBElapsedTime += Time.deltaTime;
            if(_pBElapsedTime > _playerBulletCT)
            {
                _playerBulletStartCT = false;
                _pBElapsedTime = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _OnGround = true;
        }
    }
}
