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
        #region TitleScene�ɂ���Ƃ��̏���
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)//Fade���ɃL�[�������Ă��܂����ߗv�C��
            {
                SceneManager.LoadScene("TutorialScene");
            }
        }
        #endregion

        #region TutorialScene�ɂ���Ƃ��̏���
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
        #endregion

        #region PlayScene�ɂ���Ƃ��̏���
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            if (GetComponent<Timer>()._min == 3)
            {
                SceneManager.LoadScene("GameClearScene");
            }
        }
        #endregion

        #region GameClearScene�ɂ���Ƃ��̏���
        if (SceneManager.GetActiveScene().name == "GameClearScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        #endregion

        #region GameOverScene�ɂ���Ƃ��̏���
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))//Fade���ɃL�[�������Ă��܂����ߗv�C��
            {
                Instantiate(_restartFade, _sceneManager.position, Quaternion.identity);
            }
        }
        #endregion
    }
}