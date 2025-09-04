using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    [SerializeField]
    AudioSource _bGMAudioSource;
    [SerializeField]
    AudioSource _sEAudioSource;

    #region TitleScene‚Å‚Ì‰¹º‚ğ•Û‘¶‚·‚é•Ï”
    [SerializeField]
    AudioClip _startSEClip;
    [SerializeField]
    AudioClip _titleBGMClip;
    #endregion

    #region TutorialScene‚Å‚Ì‰¹º‚ğ•Û‘¶‚·‚é•Ï”
    [SerializeField]
    AudioClip _gameStartSEClip;
    #endregion

    #region PlayScene‚Å‚Ì‰¹º‚ğ•Û‘¶‚·‚é•Ï”
    [SerializeField]
    AudioClip _upperImpulseSEClip;
    [SerializeField]
    AudioClip _playBGMClip;
    #endregion

    #region GameClearScene‚Å‚Ì‰¹º‚ğ•Û‘¶‚·‚é•Ï”
    [SerializeField]
    AudioClip _restartGameClearSEClip;
    [SerializeField]
    AudioClip _gameClearBGMClip;
    #endregion

    #region GameOverScene‚Å‚Ì‰¹º‚ğ•Û‘¶‚·‚é•Ï”
    [SerializeField]
    AudioClip _restartGameOverSEClip;
    [SerializeField]
    AudioClip _gameOverBGMClip;
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

        #region TitleScene‚Å‚ÌBGM‚Ìˆ—
        if (scene.name == "TitleScene")
        {
            _bGMAudioSource.clip = _titleBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion

        #region TutorialScene‚Å‚ÌBGM‚Ìˆ—
        #endregion

        #region PlayScene‚Å‚ÌBGM‚Ìˆ—
        if (scene.name == "PlayScene")
        {
            _bGMAudioSource.clip = _playBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion

        #region GameClearScene‚Å‚ÌBGM‚Ìˆ—
        if (scene.name == "GameClearScene")
        {
            _bGMAudioSource.clip = _gameClearBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion

        #region GameOverScene‚Å‚ÌBGM‚Ìˆ—
        if (scene.name == "GameOverScene")
        {
            _bGMAudioSource.clip = _gameOverBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion
    }

    void Update()
    {
        #region TitleScene‚Å‚ÌSE‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                _sEAudioSource.PlayOneShot(_startSEClip);
            }
        }
        #endregion

        #region TutorialScene‚Å‚ÌSE‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _sEAudioSource.PlayOneShot(_gameStartSEClip);
            }
        }
        #endregion

        #region PlayScene‚Å‚ÌSE‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _sEAudioSource.PlayOneShot(_upperImpulseSEClip);
            }
        }
        #endregion

        #region GameClearScene‚Å‚ÌSE‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.anyKeyDown)
            {
                _sEAudioSource.PlayOneShot(_restartGameClearSEClip);
            }
        }
        #endregion

        #region GameOverScene‚Å‚ÌSE‚Ìˆ—
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
