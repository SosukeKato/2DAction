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

    bool _OnFloor;
    public Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x²‚ÌˆÚ“®ˆ—
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(x, 0).normalized;
        _rb.velocity = velocity * _MoveSpeed;
        //ƒWƒƒƒ“ƒv‚Ìˆ—
    }
}
