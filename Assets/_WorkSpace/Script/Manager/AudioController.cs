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

    #region 他のスクリプトを呼び出すための変数
    GameObject _playerObj;
    PlayerAction _pAc;
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
        if (scene.name == "EasyStage")
        {
            _bGMAudioSource.clip = _playBGMClip;
            _bGMAudioSource.Play();
            #region 特定のGameObjectに付属しているコンポーネントを取得する処理
            _playerObj = GameObject.FindGameObjectWithTag("Player");
            _pAc = _playerObj.GetComponent<PlayerAction>();
            #endregion
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
        if (SceneManager.GetActiveScene().name == "EasyStage")
        {
            if (Input.GetKeyDown(KeyCode.M) && _pAc._upperImpulseStartCT == false)
            {
                _sEAudioSource.PlayOneShot(_upperImpulseSEClip);
            }
            if (Input.GetKeyDown(KeyCode.I) && _pAc._overHeadAttackStartCT == false)
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

    #region TitleSceneでのSEの処理
    public void TitleButtonClick()
    {
        _sEAudioSource.PlayOneShot(_startSEClip);
    }
    #endregion
}
