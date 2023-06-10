using UnityEngine;

public class Storage: MonoBehaviour{
    private int _countTree;
    private int _countIron;
    private int _countStone;

    private void Awake() {
        _countTree = 0;
        _countIron = 0;
        _countStone = 0;
        EventsHolder.ResourceProduced += OnResourceProduced;
    }

    private void OnDestroy() {
        EventsHolder.ResourceProduced -= OnResourceProduced;
    }

    private void OnResourceProduced(TypeResource typeResource, int count) {
        UpdateUI(typeResource, count);
    }

    private void UpdateUI(TypeResource typeResource, int count) {
        switch (typeResource) {
            case TypeResource.Tree:
                _countTree += count;
                EventsHolder.UpdateStorageUI(typeResource, _countTree);
                break;
            case TypeResource.Iron:
                _countIron += count;
                EventsHolder.UpdateStorageUI(typeResource, _countIron);
                break;
            case TypeResource.Stone:
                _countStone += count;
                EventsHolder.UpdateStorageUI(typeResource, _countStone);
                break;
        }
    }
}