using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingSettings{
    public TypeBuilding TypeBuilding;
    public Building BuildingPrefab;
    public List<BuildingsStartPositionsData> BuildingPositions;
}