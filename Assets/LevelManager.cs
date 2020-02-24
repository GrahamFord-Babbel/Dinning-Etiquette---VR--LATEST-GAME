using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(startTimer == true)
        {
            currentTime += Time.deltaTime;
            timeRemaining = gameOverTime - currentTime;
            scoreKeeper.timeRemaining = timeRemaining;
        }

        //start game/remove UIs
        if (Input.GetKeyDown(KeyCode.P))
        {

            print("space key was pressed");

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
                //print game over time
                Debug.Log("Time is: " + currentTime);
                //resent game over time
                currentTime = 0;
                //set timer to false while players rebegin
                startTimer = false;
                //gameOverScore = 0; already done in ScoreKeeper
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            //start spawning bottles
            spawner.SetActive(true);
        }

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
