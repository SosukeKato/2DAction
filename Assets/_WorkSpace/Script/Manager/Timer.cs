using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    static Timer instance { get; set; }

    [SerializeField]
    TextMeshProUGUI TimerText;

    float _sec;
    public float _min;

    void Update()
    {
        #region Timer‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "EasyStage")
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

        TimerText.text = _min.ToString("00") + ":" + ((int)_sec).ToString("00");
    }
}
