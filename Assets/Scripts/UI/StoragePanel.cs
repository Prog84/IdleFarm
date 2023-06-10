using System;
using UnityEngine;
using UnityEngine.UI;

public class StoragePanel: MonoBehaviour{

    [SerializeField] private Text _labelTree;
    [SerializeField] private Text _labelIron;
    [SerializeField] private Text _labelStone;

    private void Awake() {
        EventsHolder.StorageUpdated += OnStorageUpdated;
    }
    
    private void OnDestroy() {
        EventsHolder.StorageUpdated -= OnStorageUpdated;
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
        }
    }
}
