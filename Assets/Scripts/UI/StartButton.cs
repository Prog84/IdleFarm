using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton: MonoBehaviour{
    [SerializeField] private Button _startButton;
    
    private const string levelScene = "LevelScene"; 

    private void Awake() {
        _startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnDestroy() {
        _startButton.onClick.RemoveListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked() {
        SceneManager.LoadSceneAsync(levelScene);
    }
}