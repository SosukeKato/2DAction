using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttackObject : MonoBehaviour
{
    [SerializeField]
    float _attackDuration;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(_attackDuration);
        Destroy(gameObject);
    }
}
