using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerAttackObject : MonoBehaviour
{
    [SerializeField]
    float _attackDuration;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_attackDuration);
        Destroy(gameObject);
    }
}
