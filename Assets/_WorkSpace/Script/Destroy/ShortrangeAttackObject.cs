using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortrangeAttackObject : MonoBehaviour
{
    [SerializeField]
    float _AttackDuration;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_AttackDuration);
        Destroy(gameObject);
    }
}
