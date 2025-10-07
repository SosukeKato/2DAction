using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    static SceneController instance { get; set; }

    [SerializeField]
    GameObject _restartFade;
    [SerializeField]
    Transform _sceneManager;

    GameObject playerObj;
    PlayerHealth _pH;
    GameObject BossObj;
    void Awake()
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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        _pH = playerObj.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        #region TutorialScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        #endregion

        #region PlayScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "EasyStage")
        {
            if (_pH._death)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
        #endregion

        #region GameClearScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        #endregion

        #region GameOverScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))//Fade’†‚ÉƒL[‚ª‰Ÿ‚¹‚Ä‚µ‚Ü‚¤‚½‚ß—vC³
            {
                Instantiate(_restartFade, _sceneManager.position, Quaternion.identity);
            }
        }
        #endregion
    }

    #region TitleScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    #endregion
}