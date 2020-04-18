using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Job Summary - responsible for managing the START/GAMEOVER UIs, updating the TimeRemaining, indicating to start spawning gameObjects on GameStart
public class LevelManager : MonoBehaviour
{
    public GameObject[] uIs;
    public ScoreKeeper scoreKeeper;
    public float currentTime;
    public float timeRemaining;
    public float gameOverTime;
    public int gameOverScore;
    public bool gameOver;
    public bool startTimer;

    //get the Spawner script
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            uIs = GameObject.FindGameObjectsWithTag("UI");
        }

        //deactivate spawning bottles
        spawner.SetActive(false);
    }

    public void ClickStart()
    {
        print("clicked and started");

        foreach (GameObject UI in uIs)
        {
            UI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //keeps track of time remaining in game - TODO - add a multiplayer property (NORMCORE) for this value, currently non-synced
        if(startTimer == true)
        {
            currentTime += Time.deltaTime;
            timeRemaining = gameOverTime - currentTime;
            scoreKeeper.timeRemaining = timeRemaining;
        }

        //start game/remove UIs
        if (Input.GetKeyDown(KeyCode.P))
        {
            //check to see if keyboard working
            Debug.Log("Player has pressed the START key");

            //set the time back to normal
            Time.timeScale = 1;
   
                foreach (GameObject UI in uIs)
                {
                    UI.SetActive(false);
                    startTimer = true;
                }

            //restart game
            if (gameOver)
            {
                //reset gameover 
                gameOver = false;
                //resent game over time
                currentTime = 0;
                //set timer to false while players rebegin
                startTimer = false;
                //reload the scene - to easily reset all the values - TODO - Unload before Reloading?
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //pause the game Time
                Time.timeScale = 0;
            }

            //start spawning bottles - so VR headset can start throwing them
            spawner.SetActive(true);
        }

        //to stop the players from continuing play by activating the UIs
        if(scoreKeeper.gameScore >= gameOverScore || currentTime >= gameOverTime)
        {
            foreach (GameObject UI in uIs)
            {
                UI.SetActive(true);
            }

            gameOver = true;

            //start spawning bottles
            spawner.SetActive(false);
        }
    }
}
