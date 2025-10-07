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
    }

    void Update()
    {
        #region TutorialScene�ɂ���Ƃ��̏���
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        #endregion

        #region PlayScene�ɂ���Ƃ��̏���
        if (SceneManager.GetActiveScene().name == "EasyStage")
        {
            
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

    #region TitleScene�ɂ���Ƃ��̏���
    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    #endregion
}