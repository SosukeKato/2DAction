using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamp : MonoBehaviour
{
    Transform _tr;
    [SerializeField]
    float _minY = 2f;
    [SerializeField]
    float _maxY = 5f;
    [SerializeField]
    float _minX = -11f;
    [SerializeField]
    float _maxX = 11f;

    void Start()
    {
        _tr = transform;
    }

    void Update()
    {
        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        _tr.position = pos;
    }
}
