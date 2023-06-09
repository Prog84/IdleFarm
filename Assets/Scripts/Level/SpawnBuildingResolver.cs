using System.Collections.Generic;

public class SpawnBuildingResolver: ISpawnBuildingResolver{
    private static SpawnBuildingResolver instance;
    
    public static SpawnBuildingResolver Instance() {
        if (instance == null)
            instance = new SpawnBuildingResolver();
        return instance;
    }

    List<IResolveSpawnBuildingRule> _rules = new List<IResolveSpawnBuildingRule>();

    private SpawnBuildingResolver() {
        _rules.Add(new SpawnMineResolveRule());
        _rules.Add(new SpawnCraftBuildingResolveRule());
        _rules.Add(new SpawnMarketBuildingResolveRule());
    }

    public bool SpawnBuildingResolve(TypeBuilding typeBuilding) {
        var result = false;
        foreach (var rule in _rules) {
            
            result = rule.ResolveSpawnBuilding(typeBuilding);
            
            if (result) {
                break;
            }
        }

        return result;
    }
        
}