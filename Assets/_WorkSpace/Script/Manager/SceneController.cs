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

        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        #region TutorialScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
        #endregion

        #region PlayScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (GetComponent<Timer>()._min == 1)
            {
                SceneManager.LoadScene("GameClearScene");
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

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}