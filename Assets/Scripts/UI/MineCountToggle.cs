using UnityEngine;
using UnityEngine.UI;

public class MineCountToggle: MonoBehaviour{
    [SerializeField] private Toggle _countMineToggle;
    [SerializeField] private int _countMines;
    
    private void Start() {
        _countMineToggle.onValueChanged.AddListener(OnCountMineButtonClick);
        if (_countMineToggle.isOn) {
            SetStartCountMine();
        }
    }

    private void OnDestroy() {
        _countMineToggle.onValueChanged.RemoveListener(OnCountMineButtonClick);
    }
    
    private void OnCountMineButtonClick(bool isOn) {
        if (isOn) {
            SetStartCountMine();
        }
    }
    
    private void SetStartCountMine() {
        PlayerData.Instance.CurrentMineCount = _countMines;
    }
}