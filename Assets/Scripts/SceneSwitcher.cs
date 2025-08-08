using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneSwitcher : MonoBehaviour
{
    // Keep track of the currently loaded scene
    private static readonly System.Random random = new System.Random();//random object - Scene randomisation context
    public List<string> randomLevels = new List<string> {"GameScreen", "Level2"}; //list populated with active level scenes, for random selection
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
        //if (currentScene == "GameScreen") //if current level is GameScreen(level one)
        //{
        //    SceneManager.LoadScene("Level2"); //load level2
        //    currentScene = "Level2"; //assign level 2 as current screen
        //}
        //else if (currentScene == "Level2")
        //{
        //    SceneManager.LoadScene("GameScreen");
        //    currentScene = "GameScreen";
        //}
        //else
        //{
        //    Debug.LogError("Current scene is not 'GameScreen' or 'Level2'. Please check your scene names.");
        //}

        switch (currentScene)
        {
            case "GameScreen"://GameScreen is level 1
                SceneManager.LoadScene("Level2");
                currentScene = "Level2";//switch to level 2
                Debug.Log("Switched to Level 2");
                break;

            case "Level2"://we are on level 2 - execute level randomiser
                int randomIndex = random.Next(0, randomLevels.Count);
                string nextRandomScene = randomLevels[randomIndex];//get random index from level list
                SceneManager.LoadScene(nextRandomScene);
                currentScene = nextRandomScene;//assign random level as current scene
                Debug.Log("Switched to random level");
                break;

            default:
                Debug.LogError("Level name not recognised. Check level names");
                break;
        }
    }
}


