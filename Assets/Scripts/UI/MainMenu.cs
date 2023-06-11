using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _loadDataButton;

    private const string levelScene = "LevelScene";

    private void Start() {
        _loadDataButton.onClick.AddListener(OnClickLoad);
        _startButton.onClick.AddListener(OnStartButtonClicked);
        if (PlayerData.Instance.IsLoadingData) {
            _loadDataButton.gameObject.SetActive(true);
        }
        else {
            _loadDataButton.gameObject.SetActive(false);
        }
    }

    private void OnDestroy() {
        _loadDataButton.onClick.RemoveListener(OnClickLoad);
        _startButton.onClick.RemoveListener(OnStartButtonClicked);
    }

    private void OnClickLoad() {
        EventsHolder.LoadData();
        SceneManager.LoadSceneAsync(levelScene);
    }

    private void OnStartButtonClicked() {
        EventsHolder.StartNewGame();
        SceneManager.LoadSceneAsync(levelScene);
    }
}