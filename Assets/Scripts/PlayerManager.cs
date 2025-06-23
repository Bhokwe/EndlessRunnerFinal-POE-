using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;//check game state - Is game over?/is player dead?
    public GameObject GameOverPanel;//referencing game over panel - "gameEnd" - in UI scene

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public Text coinsText;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false; //if false - Game is not over yet - set as default
        isGameStarted = false;
        numberOfCoins = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0; //stop game
            GameOverPanel.SetActive(true); //trigger panel
            

        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            isGameStarted = true;
            Destroy(startingText);
        }
        coinsText.text="Coins: " + numberOfCoins;

        
    }
    

    
}
