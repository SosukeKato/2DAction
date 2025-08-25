using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    static SceneChanger instance { get; set; }

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
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("TutorialScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("PlayScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            
        }

        if (SceneManager.GetActiveScene().name == "GameClearscene")
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
}