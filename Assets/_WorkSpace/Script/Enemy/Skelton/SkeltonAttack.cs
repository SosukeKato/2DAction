using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _skeltonAttack;
    [SerializeField]
    Transform _skeltonForward;
    [SerializeField]
    float _skeltonAttackInterval;

    float _skeltonAttackTimer;
    Animator _sA;
    // Start is called before the first frame update
    void Start()
    {
        _sA = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _skeltonAttackTimer += Time.deltaTime;
        if (_skeltonAttackTimer >= _skeltonAttackInterval - 0.1) 
        {
            _sA.SetBool("SkeltonAttack", true);
            StartCoroutine("AnimationDelay");
        }
        if (_skeltonAttackTimer >= _skeltonAttackInterval)
        {
            _skeltonAttackTimer = 0;
            Instantiate(_skeltonAttack, _skeltonForward.position, Quaternion.identity);
        }
    }

    IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(0.08f);
        _sA.SetBool("SkeltonAttack", false);
    }
}
