using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Keep track of the currently loaded scene
    private string currentScene;
    public float timeToSwitch = 10f;
    public float timer=0f;
    void Start()
    {
        // Get the currently active scene's name at the start
        currentScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSwitch) 
        { 
            SwitchScene();
        }
        // Test switch when you press "Space"
        //if (currentScene != null)
        //{
        //    SwitchScene();
        //}
    }

    public void SwitchScene()
    {
        if (currentScene == "GameScreen")
        {
            SceneManager.LoadScene("Level2");
            currentScene = "Level2";
        }
        else if (currentScene == "Level2")
        {
            SceneManager.LoadScene("GameScreen");
            currentScene = "GameScreen";
        }
        else
        {
            Debug.LogError("Current scene is not 'GameScreen' or 'Level'. Please check your scene names.");
        }
    }
}


