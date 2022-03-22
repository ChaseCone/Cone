using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Button startButton;
    public GameObject player;
    public GameObject spawnManager;

    public TextMeshProUGUI enemyCount;
    private int totalEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        title.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        enemyCount.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        spawnManager.gameObject.SetActive(true);
    }

    public void updateEnemyCount(int added, int removed)
    {
        totalEnemies += added;
        totalEnemies -= removed;
        enemyCount.text = "ENEMIES- " + totalEnemies;
    }
}
