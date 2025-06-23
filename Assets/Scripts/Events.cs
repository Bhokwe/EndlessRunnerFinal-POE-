using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
