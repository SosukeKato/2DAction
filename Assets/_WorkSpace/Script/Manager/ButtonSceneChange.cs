using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    [SerializeField]
    string SceneName;
    void OnClincked()
    {
        SceneManager.LoadScene(SceneName);
    }
}
