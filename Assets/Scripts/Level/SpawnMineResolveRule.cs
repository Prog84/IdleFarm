using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnMineResolveRule : IResolveSpawnBuildingRule{
    public bool ResolveSpawnBuilding(TypeBuilding typeBuilding, List<Building> buildings) {
        if (typeBuilding == TypeBuilding.Mine) {
            var mineSettings =
                PlayerData.Instance.LevelData.BuildingsPositions.FirstOrDefault(
                    p => p.TypeBuilding == TypeBuilding.Mine);

            if (mineSettings != null) {
                for (int i = 0; i < PlayerData.Instance.CurrentMineCount; i++) {
                    if (i < mineSettings.BuildingPositions.Count) {
                        var building = GameObject.Instantiate(mineSettings.BuildingPrefab,
                            mineSettings.BuildingPositions[i].Position, Quaternion.identity);

                        var listTimes = PlayerData.Instance.BuildingTimeCrateData.ListBuildingTimeCrates.FirstOrDefault(
                            p => p.TypeBuilding == TypeBuilding.Mine);
                        if (i < listTimes.BuildingTimeCrates.Count) {
                            building.Init(typeBuilding, mineSettings.AvailableResources,
                                listTimes.BuildingTimeCrates[i]);
                        }

                        buildings.Add(building);
                    }
                    else {
                        Debug.LogError("Стартовых позиций меньше, чем количество  ресурсных зданий!!!");
                        return false;
                    }
                }

                return true;
            }
            else Debug.LogError("Нет стартовых настроек для ресурсных зданий!!!");
        }

        return false;
    }
}