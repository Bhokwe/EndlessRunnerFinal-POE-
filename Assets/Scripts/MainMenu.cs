using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        AudioClip clip = Resources.Load<AudioClip>("MainClick");

        SceneManager.LoadScene("GameScreen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
