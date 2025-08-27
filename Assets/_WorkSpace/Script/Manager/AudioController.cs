using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    [SerializeField]
    AudioSource[] _bgmSorce;
    [SerializeField]
    AudioSource[] _seSorce;
    [SerializeField]
    AudioClip[] _bGMClip;
    [SerializeField]
    AudioClip[] _sEClip;
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
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            
        }

        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            
        }

        if (SceneManager.GetActiveScene().name == "PlayScene")
        {

        }

        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {

        }
    }
}
