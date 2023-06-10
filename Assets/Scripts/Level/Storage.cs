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
                if (_countTree + count <= PlayerData.Instance.LevelData.ResourceStorageCapacity) {
                    _countTree += count;
                    EventsHolder.UpdateStorageUI(typeResource, _countTree);  
                }
                else {
                    EventsHolder.SetStopProducing(typeResource);
                }
                break;
            case TypeResource.Iron:
                if (_countIron + count <= PlayerData.Instance.LevelData.ResourceStorageCapacity) {
                    _countIron += count;
                    EventsHolder.UpdateStorageUI(typeResource, _countIron);    
                }
                else {
                    EventsHolder.SetStopProducing(typeResource);
                }
                break;
            case TypeResource.Stone:
                if (_countStone + count <= PlayerData.Instance.LevelData.ResourceStorageCapacity) {
                    _countStone += count;
                    EventsHolder.UpdateStorageUI(typeResource, _countStone);
                }
                else {
                    EventsHolder.SetStopProducing(typeResource);
                }
                break;
        }
    }
}