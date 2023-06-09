using System;
using UnityEngine;

public class BuildingPositionManager: MonoBehaviour{
    
    public ISpawnBuildingResolver spawnBuildingResolver;
    private void Start() {
        spawnBuildingResolver = SpawnBuildingResolver.Instance();
        CreateBuildings();
    }

    private void CreateBuildings() {
        
        var resultMine = spawnBuildingResolver.SpawnBuildingResolve(TypeBuilding.Mine);
        if (!resultMine) {
            Debug.LogError("Ресурсные здания не созданы!!!");
        }
        var resultCraft = spawnBuildingResolver.SpawnBuildingResolve(TypeBuilding.Craft);
        if (!resultCraft) {
            Debug.LogError("Перерабатывающие здания не созданы!!!");
        }    
        var resultMarket = spawnBuildingResolver.SpawnBuildingResolve(TypeBuilding.Market);
        if (!resultMarket) {
            Debug.LogError("Рынок не создан!!!");
        }
    }
}