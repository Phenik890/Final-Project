using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public BGScroller bg;
    public Vector3 spawnValues;

    public AudioSource musicSource;
    public AudioClip mainMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;

    public int hazardCount;

    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;

    private bool gameOver;
    private bool restart;
    private bool bgWinChange;

    public int score;

    public void Start()
    {
        gameOver = false;
        restart = false;
        bgWinChange = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        musicSource.clip = mainMusic;
        musicSource.loop = true;
        musicSource.Play();

        GameObject.FindObjectOfType<ParticleSystem>();


        GameObject backgroundObject = GameObject.FindWithTag("BG Scroller");
        if (backgroundObject != null)
        {
            bg = GetComponent<BGScroller>();
        }

        if (bg == null)
        {
            Debug.Log("Cannot find 'BGScroller' Script");
        }
    }

    public void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (gameOver)
        {
            restartText.text = "Press 'E' to Restart";
            restart = true;
        }

        if (bgWinChange == true)
        {
            BGChange();
        }
    }

    public IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score + " Points";

        if (score >= 250)
        {
            restartText.text = "Press 'E' to Restart";
            winText.text = "You Win! Game created by Hunter Chang! Press E to Restart";
            restart = true;
            bgWinChange = true;
            gameOver = true;
            VictoryMusic();
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    public void BGChange()
    {
        bg.BGSpeedUp();
    }

    public void VictoryMusic()
    {
        musicSource.loop = false;
        musicSource.clip = winMusic;
        musicSource.Play();
    }

    public void DefeatMusic()
    {
        musicSource.loop = false;
        musicSource.clip = loseMusic;
        musicSource.Play();
    }
}