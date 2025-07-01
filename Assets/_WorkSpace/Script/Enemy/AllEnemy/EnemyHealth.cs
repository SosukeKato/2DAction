using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    bool _Death;
    [SerializeField]
    public int _Health = 100;
    [SerializeField]
    int _MaxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Health <= 0)
        {
            _Death = true;
        }
        else
        {
            _Death = false;
        }
        if (_Health >= _MaxHealth)
        {
            _Health = _MaxHealth;
        }
        if (_Death == true)
        {
            Destroy(gameObject);
        }
    }
}
