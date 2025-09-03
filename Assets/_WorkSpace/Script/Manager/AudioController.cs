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

    #region PlayScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioSource _UpperImpulseSESorce;
    [SerializeField]
    AudioClip _UpperImpulseSEClip;
    #endregion

    #region GameClearScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioSource _restartGameClearSESorce;
    [SerializeField]
    AudioClip _restartGameClearSEClip;
    #endregion

    #region GameOverScene�ł̉�����ۑ�����ϐ�
    [SerializeField]
    AudioSource _restartGameOverSESorce;
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

        #region PlayScene�ł̏���
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _UpperImpulseSESorce.PlayOneShot(_UpperImpulseSEClip);
            }
        }
        #endregion

        #region GameClearScene�ł̏���
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.anyKeyDown)
            {
                _restartGameClearSESorce.PlayOneShot(_restartGameClearSEClip);
            }
        }
        #endregion

        #region GameOverScene�̏���
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (Input.anyKeyDown)
            {
                _restartGameOverSESorce.PlayOneShot(_restartGameOverSEClip);
            }
        }
        #endregion 
    }
}
