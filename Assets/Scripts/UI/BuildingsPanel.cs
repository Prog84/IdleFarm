using System;
using UnityEngine;

public class BuildingsPanel: MonoBehaviour{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private MinePanel _minePanel;
    [SerializeField] private CraftPanel _craftPanel;
    [SerializeField] private MarketPanel _marketPanel;
    
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
                _craftPanel.gameObject.SetActive(false);
                _marketPanel.gameObject.SetActive(false);
                _minePanel.gameObject.SetActive(true);
                ChangePanelVisibility(true);
                _minePanel.Init(building);
                break;
            case TypeBuilding.Craft:
                _minePanel.gameObject.SetActive(false);
                _marketPanel.gameObject.SetActive(false);
                _craftPanel.gameObject.SetActive(true);
                ChangePanelVisibility(true);
                _craftPanel.Init(building);
                break;
            case TypeBuilding.Market:
                _minePanel.gameObject.SetActive(false);
                _craftPanel.gameObject.SetActive(false);
                _marketPanel.gameObject.SetActive(true);
                ChangePanelVisibility(true);
                _marketPanel.Init(building);
                break;
        }
    }

    public void ChangePanelVisibility(bool isEnable) {
        _canvasGroup.alpha = isEnable ? 1f : 0f;
        _canvasGroup.interactable = isEnable;
        _canvasGroup.blocksRaycasts = isEnable;
    }
}