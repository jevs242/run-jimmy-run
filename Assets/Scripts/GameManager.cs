using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private Slider _resistenceSlider;


    private bool _beginPlay = false;
    private float _distance = 0;
    private int _lastRandom = -1;

    // Start is called before the first frame update
    void Start()
    {
        //_player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        _menuScreen.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!GetBeginPlay()) return;
        _distance += Time.deltaTime * (int)_player.gameObject.GetComponent<Player>().speed;
        SetUI();
    }

    public void BeginPlay()
    {
        //_player.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        ResumeGame();
        _gameScreen.gameObject.SetActive(true);
        _beginPlay = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        _beginPlay = false;
        //Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _beginPlay = true;
        //Time.timeScale = 1;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IsDead()
    {
        _gameOverScreen.SetActive(true);
        _player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        _gameScreen.gameObject.SetActive(false);
        Player player = _player.gameObject.GetComponent<Player>();
        player.enabled = false;
        player.speed = 0;
        player.PlayParticule();
    }

    private void SetUI()
    {
        _distanceText.text = $"{string.Format(String.Format("{0:N0}", (int)_distance))}";
        _resistenceSlider.value = _player.gameObject.GetComponent<Player>().GetPercentResistence();
    }

    public void SetPause()
    {
        if(_gameOverScreen.activeSelf || _menuScreen.activeSelf ) { return; }
        _gameScreen.gameObject.SetActive(false);
        PauseGame();
        _pauseScreen.SetActive(true);
    }

    public void SetLastRandom(int random)
    {
        _lastRandom = random;
    }

    public int GetLastRandom()
    {
        return _lastRandom;
    }

    public bool GetBeginPlay()
    {
        return _beginPlay;
    }
}
