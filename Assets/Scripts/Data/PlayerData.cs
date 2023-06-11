using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData: MonoBehaviour{

    [SerializeField] private LevelData _levelData;
    [SerializeField] private ResourceData _resourceData;
    [SerializeField] private BuildingTimeCrateData _buildingTimeCrateData;
    [SerializeField] private CraftData _craftData;
    [SerializeField] private LevelGoalData _levelGoalData;

    private Dictionary<TypeResource, int> _playerResources = new Dictionary<TypeResource, int>();

    public LevelData LevelData => _levelData;
    public ResourceData ResourceData => _resourceData;
    public BuildingTimeCrateData BuildingTimeCrateData => _buildingTimeCrateData;
    public LevelGoalData LevelGoalData => _levelGoalData;
    public CraftData CraftData => _craftData;

    public int CurrentMineCount = 0;
    public int CurrentLevelIndex = 0;

    public static PlayerData Instance = null;

    private void Awake() {
       
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        EventsHolder.ResourceProduced += OnResourceProduced;
        EventsHolder.RecourseRemoved += OnResourceRemoved;
        EventsHolder.ProductSold += OnProductSold;
        Init();
    }

    private void OnDestroy() {
        EventsHolder.ResourceProduced -= OnResourceProduced;
        EventsHolder.RecourseRemoved += OnResourceRemoved;
        EventsHolder.ProductSold -= OnProductSold;
    }

    private void Init() {

        foreach (TypeResource typeResource in Enum.GetValues(typeof(TypeResource)))
        {
            if (!_playerResources.ContainsKey(typeResource))
            {
                _playerResources.Add(typeResource, 0);
            }
        }
    }

    private void OnResourceProduced(TypeResource typeResource, int count) {
        UpdateUI(typeResource, count);
    }

    private void UpdateUI(TypeResource typeResource, int count) {
        if (_playerResources.ContainsKey(typeResource)) {
            _playerResources[typeResource] += count;
            EventsHolder.UpdateStorageUI(typeResource, _playerResources[typeResource]); 
        }
    }
    
    public bool CheckCountResources(CraftItem craftItem) {

        bool isEnoughFirst = false;
        
        if (_playerResources.ContainsKey(craftItem.NeedFirstResource.TypeResource)) {
            if (craftItem.NeedFirstResource.quantity <= _playerResources[craftItem.NeedFirstResource.TypeResource]) {
                isEnoughFirst = true;
            }
        }

        bool isEnoughSecond = false;
        
        if (_playerResources.ContainsKey(craftItem.NeedSecondResource.TypeResource)) {
            if (craftItem.NeedSecondResource.quantity <= _playerResources[craftItem.NeedSecondResource.TypeResource]) {
                isEnoughSecond = true;
            }
        }

        if (isEnoughFirst && isEnoughSecond) {
            return true;
        }
        else {
            return false;
        }
    }
    
    private void OnResourceRemoved(RecourseItem firstNeedResource, RecourseItem secondNeedResource) {
        RemoveResource(firstNeedResource);
        RemoveResource(secondNeedResource);
    }

    private void RemoveResource(RecourseItem typeResource) {
        if (_playerResources.ContainsKey(typeResource.TypeResource)) {
            _playerResources[typeResource.TypeResource]-= typeResource.quantity;
            EventsHolder.UpdateStorageUI(typeResource.TypeResource, _playerResources[typeResource.TypeResource]); 
        }
    }
    
    private void OnProductSold(ResourceSettings resourceSettings) {
        if (_playerResources.ContainsKey(resourceSettings.TypeResource)) {
            _playerResources[TypeResource.Money] +=
                _playerResources[resourceSettings.TypeResource] * resourceSettings.price;
            _playerResources[resourceSettings.TypeResource] = 0;
            EventsHolder.UpdateStorageUI(TypeResource.Money, _playerResources[TypeResource.Money]); 
            EventsHolder.UpdateStorageUI(resourceSettings.TypeResource, _playerResources[resourceSettings.TypeResource]); 
        }
    }
    
}