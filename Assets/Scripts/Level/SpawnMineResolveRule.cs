using System.Linq;
using UnityEngine;

public class SpawnMineResolveRule: IResolveSpawnBuildingRule{
    public bool ResolveSpawnBuilding(TypeBuilding typeBuilding) {
        if (typeBuilding == TypeBuilding.Mine) {

            var mineSettings = PlayerData.Instance.LevelData.BuildingsPositions.FirstOrDefault(p => p.TypeBuilding == TypeBuilding.Mine);

            if (mineSettings != null) {
                for (int i = 0; i < PlayerData.Instance.CurrentMineCount; i++) {
                    if (i < mineSettings.BuildingPositions.Count) {
                        GameObject.Instantiate(mineSettings.BuildingPrefab, mineSettings.BuildingPositions[i].Position, Quaternion.identity);
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