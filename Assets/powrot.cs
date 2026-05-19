using UnityEngine;
using UnityEngine.SceneManagement;

public class powrot : MonoBehaviour
{
    public static string lastlevel;
    public void powrotlevel()
    {
        SceneManager.LoadScene(lastlevel);
    }
    public static void deathscreen(string last) { SceneManager.LoadScene("game fail");
        lastlevel = last;

    }
    
}

