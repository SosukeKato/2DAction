using System.Collections;
using UnityEngine;

public class PlayerAttackObject : MonoBehaviour
{
    [SerializeField]
    float _attackDuration;
    IEnumerator Start()
    {
        Application.targetFrameRate = 30;
        yield return new WaitForSeconds(_attackDuration);
        Destroy(gameObject);
    }
}
