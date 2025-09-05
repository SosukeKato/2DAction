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
        #region TitleSceneにいるときの処理
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)//Fade中にキーが押せてしまうため要修正
            {
                SceneManager.LoadScene("TutorialScene");
            }
        }
        #endregion

        #region TutorialSceneにいるときの処理
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
        #endregion

        #region PlaySceneにいるときの処理
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (GetComponent<Timer>()._min == 3)
            {
                SceneManager.LoadScene("GameClearScene");
            }
        }
        #endregion

        #region GameClearSceneにいるときの処理
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        #endregion

        #region GameOverSceneにいるときの処理
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))//Fade中にキーが押せてしまうため要修正
            {
                Instantiate(_restartFade, _sceneManager.position, Quaternion.identity);
            }
        }
        #endregion
    }
}