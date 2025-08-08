using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour, IListener
{
    public static bool gameOver;//check game state - Is game over?/is player dead?
    public GameObject GameOverPanel;//referencing game over panel - "gameEnd" - in UI scene

    //public static bool nextLevel;
    //public GameObject newScene;


    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public Text coinsText;

    public static int score;
    public Text ScoreText;


    //public int Score
    //{
    //    get { return score; }
    //    set {  score = value; }




    //}

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false; //if false - Game is not over yet - set as default
        isGameStarted = false;
        numberOfCoins = 0;
        score = 0;
        EventBus.Instance.AddListener(EventType.OBSTACLE_PASSED, this);
        //nextLevel = false;

    }
    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener(EventType.OBSTACLE_PASSED, this);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0; //stop game
            CloudSave.Instance.SaveData(); //Save data when game is over - should save data in every instance that timescale is 0.
            GameOverPanel.SetActive(true); //trigger panel


        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            isGameStarted = true;
            Destroy(startingText);
        }
        coinsText.text="Coins: " + numberOfCoins;
        //ScoreText.text = "Score: " + score;


    }

    public void OnEvent (EventType eventType, Component sender, object param = null)
    {

    }


}
