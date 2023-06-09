using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingSettings{
    public TypeBuilding TypeBuilding;
    public GameObject BuildingPrefab;
    
    public List<BuildingsStartPositionsData> BuildingPositions;
}