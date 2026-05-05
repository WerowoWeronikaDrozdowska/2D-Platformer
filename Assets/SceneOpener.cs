using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    public string sceneName;

    public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}