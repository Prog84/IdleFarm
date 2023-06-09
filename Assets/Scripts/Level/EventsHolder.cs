using System;

public static class EventsHolder{
    public static event Action<Building> BuildingClicked;
    public static event Action<Building> StartProducingClicked;

    public static void SetBuildingClick(Building building) {
        BuildingClicked?.Invoke(building);
    }

    public static void SetStartProducingClick(Building building) {
        StartProducingClicked?.Invoke(building);
    }
}