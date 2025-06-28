using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerPositionClamp : MonoBehaviour
{
    [SerializeField]
    float _minY = 5f;
    [SerializeField]
    float _maxY = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;
    }
}
