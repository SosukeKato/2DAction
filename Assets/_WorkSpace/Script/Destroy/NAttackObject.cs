using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAttackObject : MonoBehaviour
{
    [SerializeField]
    float _attackDuration;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(_attackDuration);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
