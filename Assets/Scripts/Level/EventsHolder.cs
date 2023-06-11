using System;

public static class EventsHolder{
    public static event Action<Building> BuildingClicked;
    public static event Action<Building, TypeResource> ProductionStarted;
    public static event Action<TypeResource, int> ResourceProduced;
    public static event Action<TypeResource, int> StorageUpdated;
    public static event Action<RecourseItem, RecourseItem> RecourseRemoved;
    
    public static event Action<TypeResource> CraftStopped;
    public static event Action<ResourceSettings> ProductSold;

    public static void SetBuildingClick(Building building) {
        BuildingClicked?.Invoke(building);
    }

    public static void SetStartProducingClick(Building building, TypeResource typeResource) {
        ProductionStarted?.Invoke(building, typeResource);
    }
    
    public static void SetResourceProduced(TypeResource typeResource, int count) {
        ResourceProduced?.Invoke(typeResource, count);
    }
    
    public static void UpdateStorageUI(TypeResource typeResource, int count) {
        StorageUpdated?.Invoke(typeResource, count);
    }
    
    public static void RemoveResourcesToCraft(RecourseItem firstNeedResource, RecourseItem secondNeedResource) {
        RecourseRemoved?.Invoke(firstNeedResource, secondNeedResource);
    }
    
    public static void StopCraft(TypeResource typeResource) {
        CraftStopped?.Invoke(typeResource);
    }
    
    public static void SellProduct(ResourceSettings resourceSettings) {
        ProductSold?.Invoke(resourceSettings);
    }
}