using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPositionManager : MonoBehaviour{
    public ISpawnBuildingResolver spawnBuildingResolver;
    private readonly List<Building> _buildings = new List<Building>();

    private void Start() {
        spawnBuildingResolver = SpawnBuildingResolver.Instance();
        CreateBuildings();
    }

    private void CreateBuildings() {
        var resultMine = spawnBuildingResolver.SpawnBuildingResolve(TypeBuilding.Mine, _buildings);
        if (!resultMine) {
            Debug.LogError("Ресурсные здания не созданы!!!");
        }

        var resultCraft = spawnBuildingResolver.SpawnBuildingResolve(TypeBuilding.Craft, _buildings);
        if (!resultCraft) {
            Debug.LogError("Перерабатывающие здания не созданы!!!");
        }

        var resultMarket = spawnBuildingResolver.SpawnBuildingResolve(TypeBuilding.Market, _buildings);
        if (!resultMarket) {
            Debug.LogError("Рынок не создан!!!");
        }
    }
}