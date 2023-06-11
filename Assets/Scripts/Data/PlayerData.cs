using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveManager))]
public class PlayerData : MonoBehaviour{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private ResourceData _resourceData;
    [SerializeField] private BuildingTimeCrateData _buildingTimeCrateData;
    [SerializeField] private CraftData _craftData;
    [SerializeField] private LevelGoalData _levelGoalData;
    public ISaveManager SaveManager;

    private readonly Dictionary<TypeResource, int> _playerResources = new Dictionary<TypeResource, int>();

    public LevelData LevelData => _levelData;
    public ResourceData ResourceData => _resourceData;
    public BuildingTimeCrateData BuildingTimeCrateData => _buildingTimeCrateData;
    public LevelGoalData LevelGoalData => _levelGoalData;
    public CraftData CraftData => _craftData;
    public Dictionary<TypeResource, int> PlayerResources => _playerResources;

    public int CurrentMineCount = 0;
    public int CurrentLevelIndex = 0;
    public bool IsLoadingData;

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
        EventsHolder.DataLoaded += OnDataLoad;
        EventsHolder.NewGameStarted += SaveGame;
        EventsHolder.OldDataCleared += OnClearOldData;
        SaveManager = GetComponent<SaveManager>();
        Init();
    }

    private void OnDestroy() {
        EventsHolder.ResourceProduced -= OnResourceProduced;
        EventsHolder.RecourseRemoved -= OnResourceRemoved;
        EventsHolder.ProductSold -= OnProductSold;
        EventsHolder.DataLoaded -= OnDataLoad;
        EventsHolder.NewGameStarted -= SaveGame;
        EventsHolder.OldDataCleared -= OnClearOldData;
    }

    private void Init() {
        InitStartData();

        var saveData = SaveManager.Load();

        if (saveData.PlayerResourcesKey != null) {
            IsLoadingData = true;
        }
    }

    private void InitStartData() {
        foreach (TypeResource typeResource in Enum.GetValues(typeof(TypeResource))) {
            if (!_playerResources.ContainsKey(typeResource)) {
                _playerResources.Add(typeResource, 0);
            }
            else {
                _playerResources[typeResource] = 0;
            }
        }

        CurrentMineCount = 0;
        IsLoadingData = false;
    }

    private void OnResourceProduced(TypeResource typeResource, int count) {
        if (_playerResources.ContainsKey(typeResource)) {
            _playerResources[typeResource] += count;
            EventsHolder.UpdateStorageUI(typeResource, _playerResources[typeResource]);
        }

        SaveGame();
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
            _playerResources[typeResource.TypeResource] -= typeResource.quantity;
            EventsHolder.UpdateStorageUI(typeResource.TypeResource, _playerResources[typeResource.TypeResource]);
        }
    }

    private void OnProductSold(ResourceSettings resourceSettings) {
        if (_playerResources.ContainsKey(resourceSettings.TypeResource)) {
            _playerResources[TypeResource.Money] +=
                _playerResources[resourceSettings.TypeResource] * resourceSettings.price;
            _playerResources[resourceSettings.TypeResource] = 0;
            EventsHolder.UpdateStorageUI(TypeResource.Money, _playerResources[TypeResource.Money]);
            EventsHolder.UpdateStorageUI(resourceSettings.TypeResource,
                _playerResources[resourceSettings.TypeResource]);
            SaveGame();
        }
    }

    private void SaveGame() {
        var saveData = new SaveData(_playerResources, CurrentMineCount, CurrentLevelIndex);
        SaveManager.Save(saveData);
    }

    private void OnDataLoad() {
        var saveData = SaveManager.Load();

        if (saveData.PlayerResourcesKey != null) {
            for (int i = 0; i < saveData.PlayerResourcesKey.Count; i++) {
                if (_playerResources.ContainsKey(saveData.PlayerResourcesKey[i])) {
                    _playerResources[saveData.PlayerResourcesKey[i]] = saveData.PlayerResourcesValue[i];
                }
            }

            CurrentMineCount = saveData.CurrentMineCount;
            CurrentLevelIndex = saveData.CurrentLevelIndex;
            IsLoadingData = true;
        }
    }

    private void OnClearOldData() {
        InitStartData();
    }
}