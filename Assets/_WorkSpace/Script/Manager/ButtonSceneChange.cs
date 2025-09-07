using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    string SceneName;
    void OnClinckState()
    {
        SceneManager.LoadScene(SceneName);
    }
}
