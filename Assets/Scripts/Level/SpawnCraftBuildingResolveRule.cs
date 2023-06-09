using System.Linq;
using UnityEngine;

public class SpawnCraftBuildingResolveRule : IResolveSpawnBuildingRule{
    public bool ResolveSpawnBuilding(TypeBuilding typeBuilding) {
        if (typeBuilding == TypeBuilding.Craft) {

            var mineSettings =
                PlayerData.Instance.LevelData.BuildingsPositions.FirstOrDefault(
                    p => p.TypeBuilding == TypeBuilding.Craft);

            if (mineSettings != null) {
                if (mineSettings.BuildingPositions.Count > 0) {
                    GameObject.Instantiate(mineSettings.BuildingPrefab, mineSettings.BuildingPositions[0].Position,
                        Quaternion.identity);
                    return true;
                } 
                else Debug.LogError("Нет стартовой позиции для перерабатывающего здания!!!");
            }
            else Debug.LogError("Нет стартовых настроек для перерабатывающего здания!!!");
        }

        return false;
    }
}