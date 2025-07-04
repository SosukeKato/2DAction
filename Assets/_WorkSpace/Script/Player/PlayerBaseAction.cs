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
        //x���̈ړ�����
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(x, 0).normalized;
        _rb.velocity = velocity * _MoveSpeed;
        //�W�����v�̏���
        if (_OnFloor == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(velocity * _Jump);
            _OnFloor = false;
        }
        //�ʏ�U���̏���
        if (Input.GetKeyDown(KeyCode.J))
        {
            
        }
        //�K�[�h�̏���
        if (Input.GetKey(KeyCode.K)) 
        {
            _InBarrier = true;
        }
        else
        {
            _InBarrier = false;
        }
        //����̏���
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _OnFloor = true;
        }
    }
}
