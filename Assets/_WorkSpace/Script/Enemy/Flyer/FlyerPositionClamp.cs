using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerPositionClamp : MonoBehaviour
{
    public Transform _tr;
    [SerializeField]
    float _minY = 2f;
    [SerializeField]
    float _maxY = 5f;
    [SerializeField]
    float _minX = -11f;
    [SerializeField]
    float _maxX = 11f;
    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        _tr.position = pos;
    }
}
