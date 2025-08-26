using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float _sec;
    public float _min;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Timer‚Ìˆ—
        _sec += Time.deltaTime;
        if (_sec >= 60 )
        {
            _sec = 0;
            _min++;
        }
        #endregion
    }
}
