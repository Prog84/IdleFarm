using UnityEngine;
using UnityEngine.UI;

public class StoragePanel: MonoBehaviour{

    [SerializeField] private Text _labelTree;
    [SerializeField] private Text _labelIron;
    [SerializeField] private Text _labelStone;
    [SerializeField] private Text _labelHummer;
    [SerializeField] private Text _labelFork;
    [SerializeField] private Text _labelDrill;
    [SerializeField] private Text _labelMoney;
    [SerializeField] private Text _labelGoal;

    private void Awake() {
        EventsHolder.StorageUpdated += OnStorageUpdated;
        SetGoal();
    }

    private void OnDestroy() {
        EventsHolder.StorageUpdated -= OnStorageUpdated;
    }
    
    private void SetGoal() {
        _labelGoal.text = "Goal " + PlayerData.Instance.LevelGoalData.LevelGoals[PlayerData.Instance.CurrentLevelIndex].goal;
    }

    private void OnStorageUpdated(TypeResource typeResource, int count) {
        switch (typeResource) {
            case TypeResource.Tree:
                _labelTree.text = count.ToString();
                break;
            case TypeResource.Iron:
                _labelIron.text = count.ToString();
                break;
            case TypeResource.Stone:
                _labelStone.text = count.ToString();
                break;
            case TypeResource.Hammer:
                _labelHummer.text = count.ToString();
                break;
            case TypeResource.Fork:
                _labelFork.text = count.ToString();
                break;
            case TypeResource.Drill:
                _labelDrill.text = count.ToString();
                break;
            case TypeResource.Money:
                _labelMoney.text = count.ToString();
                break;
        }
    }
}
