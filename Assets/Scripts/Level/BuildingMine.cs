using System.Collections.Generic;
using UnityEngine;

public class BuildingMine : CraftingBuildings{
    private void Start() {
        CurrentTime = TimeToCreate;
    }

    private void Update() {
        if (IsWorking) {
            if (CurrentTime > 0) {
                CurrentTime -= Time.deltaTime;
                if (CurrentTime <= 0) {
                    EventsHolder.SetResourceProduced(CurrentResource, ProductionQuantity);
                    CurrentTime = TimeToCreate;
                }
            }
        }
    }

    public override void Init(TypeBuilding typeBuilding, List<RecourseItem> availableRecourses,
        BuildingTimeCrate buildingTimeCrate) {
        TypeBuilding = typeBuilding;
        AvailableResources = availableRecourses;

        if (AvailableResources.Count > 0) {
            SetCurrentResource(AvailableResources[0].TypeResource);
        }

        TimeToCreate = buildingTimeCrate.TimeToCrate;
        ProductionQuantity = buildingTimeCrate.ProductionQuantity;
    }
}