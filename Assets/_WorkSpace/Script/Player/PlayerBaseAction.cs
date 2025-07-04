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
    float _Jump;
    [SerializeField]
    GameObject _NAttack;
    [SerializeField]
    bool _OnFloor;
    public bool _InBarrier;
    public Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプの処理
        if (_OnFloor == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            _rb.AddForce(Vector2.up * _Jump, ForceMode2D.Impulse);
            _OnFloor = false;
        }
        //通常攻撃の処理
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(_NAttack);
            StartCoroutine("NAttckTime");
        }
        //ガードの処理
        if (Input.GetKeyDown(KeyCode.K))
        {
            _InBarrier = true;
            StartCoroutine("BarrierTime");
        }
        //回避の処理
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
        //x軸の移動処理
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(x * _MoveSpeed, _rb.velocity.y).normalized;
        _rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _OnFloor = true;
        }
    }

    IEnumerator BarrierTime()
    {
        yield return new WaitForSeconds(1);
        _InBarrier = false;
        Debug.Log("1秒たったよ");
    }

    IEnumerator NAttckTime()
    {
        yield return new WaitForSeconds(1);
        Destroy(_NAttack.gameObject);
    }
}
