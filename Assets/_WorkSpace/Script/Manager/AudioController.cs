using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    [SerializeField]
    AudioSource _bGMAudioSource;
    [SerializeField]
    AudioSource _sEAudioSource;

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
    [SerializeField]
    AudioClip _gameClearBGMClip;
    #endregion

    #region GameOverScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioClip _restartGameOverSEClip;
    #endregion

    void Awake()
    {
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

    //void OnDestroy()
    //{
    //    if (instance == this)
    //    {
    //        SceneManager.sceneLoaded -= OnSceneLoaded;
    //    }
    //}

    //void Start()
    //{
    //    OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    //}

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _bGMAudioSource.Stop();

        #region TitleScene�ł�BGM�̏���
        if (scene.name == "TitleScene")
        {
            _bGMAudioSource.clip = _titleBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion

        #region TutorialScene�ł�BGM�̏���
        #endregion

        #region PlayScene�ł�BGM�̏���
        if (scene.name == "PlayScene")
        {
            _bGMAudioSource.clip = _playBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion

        #region GameClearScene�ł�BGM�̏���
        if (scene.name == "GameClearScene")
        {
            _bGMAudioSource.clip = _gameClearBGMClip;
            _bGMAudioSource.Play();
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
                _sEAudioSource.PlayOneShot(_startSEClip);
            }
        }
        #endregion

        #region TutorialScene�ł�SE�̏���
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _sEAudioSource.PlayOneShot(_gameStartSEClip);
            }
        }
        #endregion

        #region PlayScene�ł�SE�̏���
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _sEAudioSource.PlayOneShot(_upperImpulseSEClip);
            }
        }
        #endregion

        #region GameClearScene�ł�SE�̏���
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.anyKeyDown)
            {
                _sEAudioSource.PlayOneShot(_restartGameClearSEClip);
            }
        }
        #endregion

        #region GameOverScene�ł�SE�̏���
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (Input.anyKeyDown)
            {
                _sEAudioSource.PlayOneShot(_restartGameOverSEClip);
            }
        }
        #endregion 
    }
}
