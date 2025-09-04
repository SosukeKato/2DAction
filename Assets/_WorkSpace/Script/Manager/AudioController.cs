using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    [SerializeField]
    AudioSource _bGMAudioSource;
    [SerializeField]
    AudioSource _sEAudioSource;

    #region TitleSceneでの音声を保存する変数
    [SerializeField]
    AudioClip _startSEClip;
    [SerializeField]
    AudioClip _titleBGMClip;
    #endregion

    #region TutorialSceneでの音声を保存する変数
    [SerializeField]
    AudioClip _gameStartSEClip;
    #endregion

    #region PlaySceneでの音声を保存する変数
    [SerializeField]
    AudioClip _upperImpulseSEClip;
    [SerializeField]
    AudioClip _overHeadAttackSEClip;
    [SerializeField]
    AudioClip _playBGMClip;
    #endregion

    #region GameClearSceneでの音声を保存する変数
    [SerializeField]
    AudioClip _restartGameClearSEClip;
    [SerializeField]
    AudioClip _gameClearBGMClip;
    #endregion

    #region GameOverSceneでの音声を保存する変数
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
            SceneManager.sceneLoaded += OnSceneLoaded;//この書き方まだよくわかってない(AI)
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)//シーンがロードされたときのみ実行する関数(AI)
    {
        _bGMAudioSource.Stop();//直前のシーンで再生されてたBGMを停止する処理(AI)

        #region TitleSceneでのBGMの処理
        if (scene.name == "TitleScene")
        {
            _bGMAudioSource.clip = _titleBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion

        #region TutorialSceneでのBGMの処理
        #endregion

        #region PlaySceneでのBGMの処理
        if (scene.name == "PlayScene")
        {
            _bGMAudioSource.clip = _playBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion

        #region GameClearSceneでのBGMの処理
        if (scene.name == "GameClearScene")
        {
            _bGMAudioSource.clip = _gameClearBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion

        #region GameOverSceneでのBGMの処理
        if (scene.name == "GameOverScene")
        {
            _bGMAudioSource.clip = _gameOverBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion
    }

    void Update()
    {
        #region TitleSceneでのSEの処理
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                _sEAudioSource.PlayOneShot(_startSEClip);
            }
        }
        #endregion

        #region TutorialSceneでのSEの処理
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _sEAudioSource.PlayOneShot(_gameStartSEClip);
            }
        }
        #endregion

        #region PlaySceneでのSEの処理
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _sEAudioSource.PlayOneShot(_upperImpulseSEClip);
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                _sEAudioSource.PlayOneShot(_overHeadAttackSEClip);
            }
        }
        #endregion

        #region GameClearSceneでのSEの処理
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.anyKeyDown)
            {
                _sEAudioSource.PlayOneShot(_restartGameClearSEClip);
            }
        }
        #endregion

        #region GameOverSceneでのSEの処理
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
