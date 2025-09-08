using System.Collections;
using UnityEngine;

public class NAttackObject : MonoBehaviour
{
    [SerializeField]
    float _attackDuration;
    IEnumerator Start()
    {
        Application.targetFrameRate = 30;
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
