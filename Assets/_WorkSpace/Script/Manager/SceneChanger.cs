using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    static SceneChanger instance { get; set; }

    Fade _fade;

    [SerializeField]
    GameObject _restartFade;
    [SerializeField]
    Transform _sceneManager;
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

    void Update()
    {
        #region TitleScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("TutorialScene");
            }
        }
        #endregion

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
            if (GetComponent<PlayerHealth>()._death == true)
            {
                SceneManager.LoadScene("GameOverScene");
            }
            if (GetComponent<GameController>()._min == 3)
            {
                SceneManager.LoadScene("GameClearScene");
            }
        }
        #endregion

        #region GameClearScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "GameClearscene")
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        #endregion

        #region GameOverScene‚É‚¢‚é‚Æ‚«‚Ìˆ—
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (Input.anyKeyDown)
            {
                Instantiate(_restartFade, _sceneManager.position, Quaternion.identity);
            }
        }
        #endregion
    }
}