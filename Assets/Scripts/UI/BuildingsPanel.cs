using System;
using UnityEngine;

public class BuildingsPanel: MonoBehaviour{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private MinePanel _minePanel;
    
    private void Awake() {
        EventsHolder.BuildingClicked += OnBuildingClicked;
        ChangePanelVisibility(false);
    }

    private void OnDestroy() {
        EventsHolder.BuildingClicked -= OnBuildingClicked;
    }

    private void OnBuildingClicked(Building building) {
        switch (building.TypeBuilding) {
            case TypeBuilding.Mine:
                ChangePanelVisibility(true);
                _minePanel.Init(building);
                break;
        }
    }

    private void ChangePanelVisibility(bool isEnable) {
        _canvasGroup.alpha = isEnable ? 1f : 0f;
        _canvasGroup.interactable = isEnable;
        _canvasGroup.blocksRaycasts = false;
    }
}