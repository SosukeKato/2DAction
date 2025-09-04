using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    [SerializeField]
    AudioSource _audioSorce;

    #region TitleScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioClip _startSEClip;
    [SerializeField]
    AudioClip _titleBGMClip;
    #endregion

    #region TutorialScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioClip _gameStartSEClip;
    #endregion

    #region PlayScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioClip _upperImpulseSEClip;
    [SerializeField]
    AudioClip _playBGMClip;
    #endregion

    #region GameClearScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioClip _restartGameClearSEClip;
    #endregion

    #region GameOverScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioClip _restartGameOverSEClip;
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

        #region TitleScene�ł̏���
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            _audioSorce.clip = _titleBGMClip;
            _audioSorce.Play();
        }
        #endregion

        #region TutorialScene�ł̏���
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {

        }
        #endregion

        #region PlayScene�ł̏���
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            _audioSorce.Stop();
            _audioSorce.clip = _playBGMClip;
            _audioSorce.Play();
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region TitleScene�ł̏���
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                _audioSorce.PlayOneShot(_startSEClip);
            }
        }
        #endregion

        #region TutorialScene�ł̏���
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _audioSorce.PlayOneShot(_gameStartSEClip);
            }
        }
        #endregion

        #region PlayScene�ł̏���
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _audioSorce.PlayOneShot(_upperImpulseSEClip);
            }
        }
        #endregion

        #region GameClearScene�ł̏���
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.anyKeyDown)
            {
                _audioSorce.PlayOneShot(_restartGameClearSEClip);
            }
        }
        #endregion

        #region GameOverScene�̏���
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (Input.anyKeyDown)
            {
                _audioSorce.PlayOneShot(_restartGameOverSEClip);
            }
        }
        #endregion 
    }
}
