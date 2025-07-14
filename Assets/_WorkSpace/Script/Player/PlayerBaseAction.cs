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
        //xé≤ÇÃà⁄ìÆèàóù
        float x = Input.GetAxisRaw("Horizontal");
        //ÉWÉÉÉìÉvÇÃèàóù
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
        //í èÌçUåÇÇÃèàóù
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(_NAttack,_PlayerFront.position,Quaternion.identity);
            StartCoroutine("NAttckTime");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _OnGround = true;
        }
    }

    IEnumerator BarrierTime()
    {
        yield return new WaitForSeconds(1);
        _InBarrier = false;
        Debug.Log("1ïbÇΩÇ¡ÇΩÇÊ");
    }

    IEnumerator NAttckTime()
    {
        yield return new WaitForSeconds(1);
        Destroy(_NAttack);
    }
}
