using System.Collections;
using UnityEngine;

public class PlayerAttackObject : MonoBehaviour
{
    [SerializeField]
    float _attackDuration;
    [SerializeField]
    int _bulletHeal = 15;

    IEnumerator Start()
    {
        Application.targetFrameRate = 30;
        yield return new WaitForSeconds(_attackDuration);
        Destroy(gameObject);
    }
}
