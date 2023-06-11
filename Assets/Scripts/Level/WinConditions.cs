using UnityEngine;

public class WinConditions : MonoBehaviour{
    [SerializeField] private GameObject _winPanel;

    private void Awake() {
        EventsHolder.StorageUpdated += OnStorageUpdated;
    }

    private void OnDestroy() {
        EventsHolder.StorageUpdated += OnStorageUpdated;
    }

    private void OnStorageUpdated(TypeResource type, int count) {
        if (type == TypeResource.Money && count >= PlayerData.Instance.LevelGoalData.LevelGoals[PlayerData.Instance.CurrentLevelIndex].goal) {
            Time.timeScale = 0f;
            _winPanel.SetActive(true);
        }
    }
}