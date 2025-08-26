using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static GameController instance { get; set; }

    float _sec;
    public float _min;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Timer‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            _sec += Time.deltaTime;
            if (_sec >= 60)
            {
                _sec = 0;
                _min++;
            }
        }
        if (SceneManager.GetActiveScene().name == "GameClearScene" || SceneManager.GetActiveScene().name == "GameOverScene")
        {
            _sec = 0;
            _min = 0;
        }
        #endregion
    }
}
