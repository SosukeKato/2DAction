using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    bool FinishFade = false;
    byte _alpha;
    [SerializeField]
    Image _fade;
    [SerializeField]
    byte _r;
    [SerializeField]
    byte _g;
    [SerializeField]
    byte _b;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!FinishFade)
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
        _fade.color = new Color32(_r, _g, _b, _alpha);
        if (_alpha == 255)
        {
            FinishFade = true;
            SceneManager.LoadScene("ChangeScene");
        }
    }

    void FadeIn()
    {
        _alpha--;
        _fade.color = new Color32(_r, _g, _b, _alpha);
        if (_alpha == 0)
        {
            Destroy(gameObject);
        }
    }
}
