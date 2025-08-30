using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    #region TitleScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioSource _startSESorce;
    [SerializeField]
    AudioClip _startSEClip;
    #endregion

    #region TutorialScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioSource _gameStartSESorce;
    [SerializeField]
    AudioClip _gameStartSEClip;
    #endregion
    [SerializeField]
    AudioSource[] _bgmSorce;
    [SerializeField]
    AudioClip[] _bGMClip;
    #region GameOverScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioSource _restartSESorce;
    [SerializeField]
    AudioClip _restartSEClip;
    #endregion
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
        #region TitleScene�ł̏���
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                _startSESorce.PlayOneShot(_startSEClip);
            }
        }
        #endregion

        #region TutorialScene�ł̏���
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _gameStartSESorce.PlayOneShot(_gameStartSEClip);
            }
        }
        #endregion

        if (SceneManager.GetActiveScene().name == "PlayScene")
        {

        }

        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {

        }

        #region GameOverScene�̏���
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (Input.anyKeyDown)
            {
                _restartSESorce.PlayOneShot(_restartSEClip);
            }
        }
        #endregion 
    }
}
