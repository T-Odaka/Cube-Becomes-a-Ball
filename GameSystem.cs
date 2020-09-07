using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#elif UNITY_STANDALONE
        {
            UnityEngine.Application.Quit();   
        }
#endif
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("Menu");
    }

}