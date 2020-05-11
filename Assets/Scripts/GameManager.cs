using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    
    //Game States
    public Canvas mainMenu;
    public Canvas inGame;
    public Canvas gameOver;
    public Canvas win;
    public Canvas pause;
    
    public Transform spawnpoint;
    public Player player;
    
    private Canvas[] _gameStates;

    public GameState currentState = 0;
    
    // Spawns
    public float healthSpawnPercentage = 0.1f;
    public GameObject healthPrefab;
	
    public float powerUpSpawnPercentage = 0.1f;
    public GameObject powerUpPrefab;
	
    public float enemySpawnPercentage = 0.1f;
    public GameObject enemyPrefab;
	
    public int collectableAmount = 4;
    public GameObject collectablePrefab;
    
    private List<GameObject> _healthPickups = new List<GameObject>();
    private List<GameObject> _collectables = new List<GameObject>();
    private List<GameObject> _enemies = new List<GameObject>();
    private List<GameObject> _powerups = new List<GameObject>();
    
    // items collected
    private int _itemsCollected;

    public int ItemsCollected {
        get { return _itemsCollected; }
        set { _itemsCollected = value; }
    }

    public Text collectableCount;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameStates = new Canvas[]{ mainMenu, inGame, win, gameOver, pause};
        SwitchState(currentState);
    }

    public void ToMainMenu() {
        SwitchState(GameState.mainMenu);
    }

    public void ToInGame() {
        ResetGame();
        SwitchState(GameState.inGame);
    }

    public void ToWin() {
        SwitchState(GameState.win);
    }

    public void ToGameOver() {
        SwitchState(GameState.gameOver);
    }
    
    public void ToUnpause() {
        SwitchState(GameState.inGame);
    }

    public void ResetGame() {
        ItemsCollected = 0;
        DestroyAllSpawnables();
        for (int i = 0; i < collectableAmount; i++) {
            _collectables.Add(Instantiate(collectablePrefab, new Vector3(Random.value * 20 - 10, 0, Random.value * 20 - 10), Quaternion.identity));
        }
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        player.transform.position = spawnpoint.position;
        player.health = 100;
        player.SetHealthUi();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void SwitchState(GameState state) {
        foreach (var gameState in _gameStates) {
            gameState.gameObject.SetActive(false);
        }
        switch (state) {
            case GameState.mainMenu:
                currentState = state;
                _gameStates[0].gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
            case GameState.inGame:
                currentState = state;
                _gameStates[1].gameObject.SetActive(true);
                Time.timeScale = 1;
                break;
            case GameState.win:
                currentState = state;
                _gameStates[2].gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
            case GameState.gameOver:
                currentState = state;
                _gameStates[3].gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
            case GameState.pause:
                currentState = state;
                _gameStates[4].gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }

    private void DestroyAllSpawnables() {
        foreach (var healthPickup in _healthPickups) {
            Destroy(healthPickup);
        }
        foreach (var collectable in _collectables) {
            Destroy(collectable);
        }
        foreach (var enemy in _enemies) {
            Destroy(enemy);
        }
        foreach (var powerup in _powerups) {
            Destroy(powerup);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            if (currentState == GameState.inGame) {
                SwitchState(GameState.pause);
            } else if (currentState == GameState.pause) {
                SwitchState(GameState.inGame);
            }
        }
        switch (currentState) {
            case GameState.mainMenu:
                break;
            case GameState.inGame:
                collectableCount.text = String.Format("{0:0}", ItemsCollected) + " / " + collectableAmount;
                if (ItemsCollected >= collectableAmount) {
                    SwitchState(GameState.win);
                }
                break;
            case GameState.win:
                break;
            case GameState.gameOver:
                break;
        }
    }
    
    private void FixedUpdate()
    {
        if (Random.value * 100 < healthSpawnPercentage) {
            _healthPickups.Add(Instantiate(healthPrefab, new Vector3(Random.value * 20 - 10, 0, Random.value * 20 - 10), Quaternion.identity));
        }
        if (Random.value * 100 < powerUpSpawnPercentage) {
            _powerups.Add(Instantiate(powerUpPrefab, new Vector3(Random.value * 20 - 10, 0, Random.value * 20 - 10), Quaternion.identity));
        }
        if (Random.value * 100 < enemySpawnPercentage) {
            _enemies.Add(Instantiate(enemyPrefab, new Vector3(Random.value * 20 - 10, 5, Random.value * 20 - 10), Quaternion.identity));
        }
    }
}
