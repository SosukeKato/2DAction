using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChanegeScene(string StageName)
    {
        SceneManager.LoadScene(StageName);
    }
}