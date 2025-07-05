using System.Collections;
using System.Collections.Generic;
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
        //x軸の移動処理
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
    }
}
