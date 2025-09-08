using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TimerText;
    [SerializeField]
    float _timeLimit;

    float _sec;
    public float _min;

    void Update()
    {
        #region Timer‚Ìˆ—
        _sec += Time.deltaTime;
        if (_sec >= 60)
        {
            _sec = 0;
            _min++;
        }
        if (_min >= _timeLimit)
        {
            Destroy(TimerText);
        }
        #endregion

        TimerText.text = _min.ToString("00") + ":" + ((int)_sec).ToString("00");
    }
}
