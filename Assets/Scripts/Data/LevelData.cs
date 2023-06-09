using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 1)]
public class LevelData : ScriptableObject{
    public List<BuildingsStartPositionsData> _mineBuildingsPositions;
    public List<BuildingsStartPositionsData> _craftBuildingsPositions;
    public List<BuildingsStartPositionsData> _marketBuildingsPositions;
}
