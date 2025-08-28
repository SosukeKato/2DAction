using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class HealItem : MonoBehaviour
{
    PlayerHealth _pH;

    [SerializeField]
    float _minY = -2.25f;
    [SerializeField]
    float _maxY = 5f;
    [SerializeField]
    int _heal = 3;

    void Start()
    {
        _pH = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _pH._playerHealth += _heal;
            Destroy(gameObject);
        }
    }
}
