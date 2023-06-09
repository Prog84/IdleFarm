using System.Collections.Generic;

public interface IResolveSpawnBuildingRule{
    bool ResolveSpawnBuilding(TypeBuilding typeBuilding, List<Building> buildings);
}