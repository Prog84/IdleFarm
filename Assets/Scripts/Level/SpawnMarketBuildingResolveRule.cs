using System.Linq;
using UnityEngine;

public class SpawnMarketBuildingResolveRule: IResolveSpawnBuildingRule{
    public bool ResolveSpawnBuilding(TypeBuilding typeBuilding) {
        if (typeBuilding == TypeBuilding.Market) {

            var mineSettings =
                PlayerData.Instance.LevelData.BuildingsPositions.FirstOrDefault(
                    p => p.TypeBuilding == TypeBuilding.Market);

            if (mineSettings != null) {
                if (mineSettings.BuildingPositions.Count > 0) {
                    GameObject.Instantiate(mineSettings.BuildingPrefab, mineSettings.BuildingPositions[0].Position,
                        Quaternion.identity);
                    return true;
                } 
                else Debug.LogError("Нет стартовой позиции для рынка!!!");
            }
            else Debug.LogError("Нет стартовых настроек для рынка!!!");
        }

        return false;
    }
}