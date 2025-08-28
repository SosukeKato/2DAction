using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    static SceneChanger instance { get; set; }

    Fade _fade;
    GameObject fade;

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

        fade = GameObject.FindGameObjectWithTag("Fade");
    }

    void Update()
    {
        #region TitleSceneにいるときの処理
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if ((Input.anyKeyDown) && (fade == null))//Fade中にキーが押せてしまうため要修正
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

        #region GameClearSceneにいるときの処理
        if (SceneManager.GetActiveScene().name == "GameClearscene")
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        #endregion

        #region GameOverSceneにいるときの処理
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if ((Input.anyKeyDown) && (fade == null))//Fade中にキーが押せてしまうため要修正
            {
                Instantiate(_restartFade, _sceneManager.position, Quaternion.identity);
            }
        }
        #endregion
    }
}