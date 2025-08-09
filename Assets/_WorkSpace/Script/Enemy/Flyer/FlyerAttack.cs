using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(EnemyAI))]
[RequireComponent (typeof(EnemyHealth))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class FlyerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _flyerAttack;
    [SerializeField]
    Transform _flyer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
