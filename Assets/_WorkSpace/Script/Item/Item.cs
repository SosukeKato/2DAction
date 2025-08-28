using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    [SerializeField]
    float _minY = -2.25f;
    [SerializeField]
    float _maxY = 5f;

    void Update()
    {
        Vector2 pos = transform.position;

        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;
    }

    public virtual void CatchItem()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
