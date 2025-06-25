using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseAction : MonoBehaviour
{
    public Rigidbody _rb;
    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
