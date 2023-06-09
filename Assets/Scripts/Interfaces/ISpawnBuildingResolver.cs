using System.Collections.Generic;

public interface ISpawnBuildingResolver{
    bool SpawnBuildingResolve(TypeBuilding typeBuilding, List<Building> buildings);
}