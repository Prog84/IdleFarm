using System;

public static class EventsHolder{
    public static event Action<Building> BuildingClicked;
    public static event Action<Building, int> ProductionStarted;
    public static event Action<TypeResource, int> ResourceProduced;
    public static event Action<TypeResource, int> StorageUpdated;
    public static event Action<TypeResource> ProductionStopped;

    public static void SetBuildingClick(Building building) {
        BuildingClicked?.Invoke(building);
    }

    public static void SetStartProducingClick(Building building, int currentResource) {
        ProductionStarted?.Invoke(building, currentResource);
    }
    
    public static void SetResourceProduced(TypeResource typeResource, int count) {
        ResourceProduced?.Invoke(typeResource, count);
    }
    
    public static void UpdateStorageUI(TypeResource typeResource, int count) {
        StorageUpdated?.Invoke(typeResource, count);
    }
    
    public static void SetStopProducing(TypeResource typeResource) {
        ProductionStopped?.Invoke(typeResource);
    }
}