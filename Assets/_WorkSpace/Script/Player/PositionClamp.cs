using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamp : MonoBehaviour
{
    [SerializeField]
    float _minX = -11f;
    [SerializeField]
    float _maxX = 11f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

        transform.position = pos;
    }
}
