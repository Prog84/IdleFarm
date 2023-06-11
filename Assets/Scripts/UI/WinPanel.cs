using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel: MonoBehaviour{
    [SerializeField] private Button _button;

    private const string menuScene = "MainMenu"; 
    private void Awake() {
        _button.onClick.AddListener(NextLevel);
        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        _button.onClick.RemoveListener(NextLevel);
    }

    private void NextLevel() {
        SceneManager.LoadSceneAsync(menuScene);
    }
}