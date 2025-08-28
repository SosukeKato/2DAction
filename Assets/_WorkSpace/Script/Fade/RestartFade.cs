using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartFade : MonoBehaviour
{
    bool Fade = false;
    byte _alpha;
    [SerializeField]
    Image _fade;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Fade)
        {
            FadeOut();
        }
        else
        {
            FadeIn();
        }
    }

    void FadeOut()
    {
        _alpha++;
        _fade.color = new Color32(0, 0, 0, _alpha);
        if (_alpha == 255)
        {
            Fade = true;
            SceneManager.LoadScene("ChangeScene");
        }
    }

    void FadeIn()
    {
        _alpha--;
        _fade.color = new Color32(0, 0, 0, _alpha);
        if (_alpha == 0)
        {
            Destroy(gameObject);
        }
    }
}
