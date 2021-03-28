using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    public Button restartButton;
    
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverScreen.gameObject.SetActive(true);


        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float minSpawnRate, float maxSpawnRate)
    {
        isGameActive = true;
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);

        UpdateScore(0);
        StartCoroutine(SpawnTarget());

        gameOverScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
    }
}
