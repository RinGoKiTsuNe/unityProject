using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public GameObject enemy;
    public Vector3 spawnValue;
    public int hazardCount=100;
    public float spawnWait=1.0f;
    public float startWait = 0.5f;
    public float waveWait = 1.0f;
    public float enemyWait = 15f;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    private AudioSource audio;

    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        StartCoroutine(SpawnWaves());
        StartCoroutine(EnemyAppear());
        UpdateScore();
        audio = GetComponent<AudioSource>();
        audio.Play();
        

    }
	
	// Update is called once per frame
	void Update () {

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {   
                SceneManager.LoadScene("sence1");
            }
        }

		
	}
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        Debug.Log("1");
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Debug.Log("2");
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPostion, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            yield return new WaitForSeconds(waveWait);
            
        }
    }

    IEnumerator EnemyAppear()
    {
        yield return new WaitForSeconds(enemyWait);
        Instantiate(enemy);
        Destroy(audio);
    }

    public void AddStore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }


    void UpdateScore()
    {

        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text="GameOver";
    }

    public void Win()
    {
        gameOver = true;
        gameOverText.text = "You Win";
    }

}
