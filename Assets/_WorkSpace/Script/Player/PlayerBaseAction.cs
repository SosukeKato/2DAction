using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerBaseAction : MonoBehaviour
{
    [SerializeField]
    float _MoveSpeed;
    [SerializeField]
    float _JumpPower;
    [SerializeField]
    GameObject _NAttack;
    [SerializeField]
    Transform _PlayerFront;
    [SerializeField]
    bool _OnGround;
    int _LeftShiftNumber = 0;
    public Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x軸の移動処理
        float x = Input.GetAxisRaw("Horizontal");
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
            StartCoroutine("NAttckTime");
        }
        //保存した位置に帰ってくるスキルの処理を追加
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _LeftShiftNumber += 1;
            if (_LeftShiftNumber % 2 == 0)
            {

            }
            else if(_LeftShiftNumber % 2 == 1)
            {

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

    IEnumerator NAttckTime()
    {
        yield return new WaitForSeconds(1);
        Destroy(_NAttack);
    }
}
