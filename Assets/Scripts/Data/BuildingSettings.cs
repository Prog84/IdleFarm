using System;
using System.Collections.Generic;

[Serializable]
public class BuildingSettings{
    public TypeBuilding TypeBuilding;
    public List<TypeResource> AvailableResources;
    public Building BuildingPrefab;
    public List<BuildingsStartPositionsData> BuildingPositions;
}