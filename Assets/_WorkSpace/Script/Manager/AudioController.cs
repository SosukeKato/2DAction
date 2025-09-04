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
        _audioSorce.Stop();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _audioSorce.Stop();

        #region TitleScene�ł�BGM�̏���
        if (scene.name == "TitleScene")
        {
            _audioSorce.clip = _titleBGMClip;
            _audioSorce.Play();
        }
        #endregion

        #region TutorialScene�ł�BGM�̏���
        if (scene.name == "TutorialScene")
        {
            // BGM�Ȃ�
        }
        #endregion

        #region PlayScene�ł�BGM�̏���
        if (scene.name == "PlayScene")
        {
            _audioSorce.clip = _playBGMClip;
            _audioSorce.Play();
        }
        #endregion

        #region GameClearScene�ł�BGM�̏���
        if (scene.name == "GameClearScene")
        {
            // BGM�Ȃ��i�K�v�ɉ����ăN���A�pBGM��ǉ��j
        }
        #endregion

        #region GameOverScene�ł�BGM�̏���
        if (scene.name == "GameOverScene")
        {
            // BGM�Ȃ��i�K�v�ɉ����ăQ�[���I�[�o�[�pBGM��ǉ��j
        }
        #endregion
    }

    void Update()
    {
        #region TitleScene�ł�SE�̏���
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                _audioSorce.PlayOneShot(_startSEClip);
            }
        }
        #endregion

        #region TutorialScene�ł�SE�̏���
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _audioSorce.PlayOneShot(_gameStartSEClip);
            }
        }
        #endregion

        #region PlayScene�ł�SE�̏���
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _audioSorce.PlayOneShot(_upperImpulseSEClip);
            }
        }
        #endregion

        #region GameClearScene�ł�SE�̏���
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.anyKeyDown)
            {
                _audioSorce.PlayOneShot(_restartGameClearSEClip);
            }
        }
        #endregion

        #region GameOverScene�ł�SE�̏���
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
