using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    GameObject _playerObj;
    PlayerAction _pAc;
    void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _pAc = _playerObj.GetComponent<PlayerAction>();
    }

    void Update()
    {
        
    }
}
