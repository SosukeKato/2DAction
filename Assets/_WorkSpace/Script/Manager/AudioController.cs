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
    AudioClip _overHeadAttackSEClip;
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
    [SerializeField]
    AudioClip _gameOverBGMClip;
    #endregion

    #region ���̃X�N���v�g���Ăяo�����߂̕ϐ�
    GameObject _playerObj;
    PlayerAction _pAc;
    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;//���̏������܂��悭�킩���ĂȂ�(AI)
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)//�V�[�������[�h���ꂽ�Ƃ��̂ݎ��s����֐�(AI)
    {
        _bGMAudioSource.Stop();//���O�̃V�[���ōĐ�����Ă�BGM���~���鏈��(AI)

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
        if (scene.name == "EasyStage")
        {
            _bGMAudioSource.clip = _playBGMClip;
            _bGMAudioSource.Play();
            #region �����GameObject�ɕt�����Ă���R���|�[�l���g���擾���鏈��
            _playerObj = GameObject.FindGameObjectWithTag("Player");
            _pAc = _playerObj.GetComponent<PlayerAction>();
            #endregion
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
            _bGMAudioSource.clip = _gameOverBGMClip;
            _bGMAudioSource.Play();
        }
        #endregion
    }

    void Update()
    {
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

    #region TitleScene�ł�SE�̏���
    public void TitleButtonClick()
    {
        _sEAudioSource.PlayOneShot(_startSEClip);
    }
    #endregion
}
