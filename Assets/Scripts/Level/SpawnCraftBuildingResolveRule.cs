using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnCraftBuildingResolveRule : IResolveSpawnBuildingRule{
    public bool ResolveSpawnBuilding(TypeBuilding typeBuilding, List<Building> buildings) {
        if (typeBuilding == TypeBuilding.Craft) {
            var craftSettings =
                PlayerData.Instance.LevelData.BuildingsPositions.FirstOrDefault(
                    p => p.TypeBuilding == TypeBuilding.Craft);

            if (craftSettings != null) {
                if (craftSettings.BuildingPositions.Count > 0) {
                    var building = GameObject.Instantiate(craftSettings.BuildingPrefab,
                        craftSettings.BuildingPositions[0].Position, Quaternion.identity);
                    var listTimes = PlayerData.Instance.BuildingTimeCrateData.ListBuildingTimeCrates.FirstOrDefault(
                        p => p.TypeBuilding == TypeBuilding.Craft);
                    if (listTimes.BuildingTimeCrates.Count > 0) {
                        building.Init(typeBuilding, craftSettings.AvailableResources, listTimes.BuildingTimeCrates[0]);
                    }

                    buildings.Add(building);
                    return true;
                }
                else Debug.LogError("Нет стартовой позиции для перерабатывающего здания!!!");
            }
            else Debug.LogError("Нет стартовых настроек для перерабатывающего здания!!!");
        }

        return false;
    }
}