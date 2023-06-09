using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 1)]
public class LevelData : ScriptableObject{
    public List<BuildingsStartPositionsData> MineBuildingsPositions;
    public List<BuildingsStartPositionsData> CraftBuildingsPositions;
    public List<BuildingsStartPositionsData> MarketBuildingsPositions;

    public BuildingPrefab MinePrefab;
    public BuildingPrefab CraftPrefab;
    public BuildingPrefab MarketPrefab;
}
