using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;//check game state - Is game over?/is player dead?
    public GameObject gameEndPanel;//referencing game over panel - "gameEnd" - in UI scene
    private bool panelActive = false;
    
    void Start()
    {
        gameOver = false; //if false - Game is not over yet - set as default
        Time.timeScale = 1;//ensure panel inactivity
        this.gameEndPanel = GameObject.Find("gameEnd"); //assigning found game object to field
        //check
        if(gameEndPanel == null)
        {
            Debug.LogWarning("gameEnd not found in scene."); //warning triggered - 09:06 - 23/06
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && !panelActive)
        {
            Time.timeScale = 0; //stop game
            
                if (gameEndPanel == null)
                {
                //gameEndPanel = GameObject.Find("gameEnd");//find game object(gameEnd Panel)


                    if (gameEndPanel == null)//check if found
                    {
                        Debug.LogError("gameEnd not found! Check name and Hierarchy.");
                        return;//NullReferenceException handling
                    }
                    else
                    {
                    Debug.Log("gameEnd Panel found!");
                    }
                }

            gameEndPanel.SetActive(true); //trigger panel
            panelActive = true; //activate panek if gameOver & !panelActive



            //if (gameEndPanel != null) //check if game object is assigned 
            //{
            //    //gameEndPanel.SetActive(true);
            //    StartCoroutine(DelayedGameOver());
            //}

        }

        //if (gameEndPanel != null) //check if game object is assigned 
        //{
        //    gameEndPanel.SetActive(false);
        //}
    }

    //private void OnTriggerEnter(Collider other)//called when a collider enters trigger(player collider) - player death
    //{
    //    if (other.CompareTag("Obstacle"))
    //    {
    //        StartCoroutine(DelayedGameOver());
    //    }
    //}

    //IEnumerator DelayedGameOver() //Co-Routine for delay - effort to curb immediate panel spawn on start
    //{
    //    yield return new WaitForSeconds(10f);
    //    gameOver = true;
    //    Debug.Log("Hit! Game over!!");
    //}
}
