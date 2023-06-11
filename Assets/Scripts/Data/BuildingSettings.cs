using System;
using System.Collections.Generic;

[Serializable]
public class BuildingSettings{
    public TypeBuilding TypeBuilding;
    public List<RecourseItem> AvailableResources;
    public Building BuildingPrefab;
    public List<BuildingsStartPositionsData> BuildingPositions;
}