using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    [SerializeField]
    AudioSource _audioSorce;

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
    #endregion

    #region GameOverScene‚Å‚Ì‰¹º‚ğ•Û‘¶‚·‚é•Ï”
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

        #region TitleScene‚Å‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            _audioSorce.clip = _titleBGMClip;
            _audioSorce.Play();
        }
        #endregion

        #region TutorialScene‚Å‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {

        }
        #endregion

        #region PlayScene‚Å‚Ìˆ—
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
        #region TitleScene‚Å‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                _audioSorce.PlayOneShot(_startSEClip);
            }
        }
        #endregion

        #region TutorialScene‚Å‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _audioSorce.PlayOneShot(_gameStartSEClip);
            }
        }
        #endregion

        #region PlayScene‚Å‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _audioSorce.PlayOneShot(_upperImpulseSEClip);
            }
        }
        #endregion

        #region GameClearScene‚Å‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.anyKeyDown)
            {
                _audioSorce.PlayOneShot(_restartGameClearSEClip);
            }
        }
        #endregion

        #region GameOverScene‚Ìˆ—
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
