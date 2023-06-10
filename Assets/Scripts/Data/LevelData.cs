using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 1)]
public class LevelData : ScriptableObject{
    public int StorageCapacity;
    public List<BuildingSettings> BuildingsPositions;
}
