using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    //Game States
    public Canvas mainMenu;
    public Canvas inGame;
    public Canvas gameOver;
    public Canvas win;
    private Canvas[] _gameStates;

    public GameState currentState = 0;
    
    // items collected
    private int _itemsCollected;

    public int ItemsCollected {
        get { return _itemsCollected; }
        set { _itemsCollected = value; }
    }

    public Text collectableCount;
    public Spawner spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameStates = new Canvas[]{ mainMenu, inGame, win, gameOver};
    }

    public void ToMainMenu() {
        SwitchState(GameState.mainMenu);
    }

    public void ToInGame() {
        SwitchState(GameState.inGame);
    }

    public void ToWin() {
        SwitchState(GameState.win);
    }

    public void ToGameOver() {
        SwitchState(GameState.gameOver);
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
                ItemsCollected = 0;
                Debug.Log("SCENE LOAD" + Time.timeScale);
                SceneManager.LoadScene(0);
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) {
            case GameState.mainMenu:
                break;
            case GameState.inGame:
                Debug.Log(Time.timeScale);
                collectableCount.text = String.Format("{0:0}", ItemsCollected) + " / " + spawner.collectableAmount;
                if (ItemsCollected >= spawner.collectableAmount) {
                    SwitchState(GameState.win);
                }
                break;
            case GameState.win:
                break;
            case GameState.gameOver:
                break;
        }
    }
}
