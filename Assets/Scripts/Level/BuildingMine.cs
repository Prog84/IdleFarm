using System.Collections.Generic;
using UnityEngine;

public class BuildingMine: CraftingBuildings{
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
    
    public override void Init(TypeBuilding typeBuilding, List<TypeResource> availableRecourses, BuildingTimeCrate buildingTimeCrate) {

        TypeBuilding = typeBuilding;
        AvailableResources = availableRecourses;

        if (AvailableResources.Count > 0) {
            SetCurrentResource(0);
        }

        TimeToCreate = buildingTimeCrate.TimeToCrate;
        ProductionQuantity = buildingTimeCrate.ProductionQuantity;
    }

    protected override void OnProductionStarted(Building building, int currentResource) {
        if (building.Equals(this)) {
            SetCurrentResource(currentResource);
            if (!IsWorking) {
                IsWorking = true;    
            }
            else {
                IsWorking = false;   
                CurrentTime = TimeToCreate;
            }
        }
    }

    private void SetCurrentResource(int index) {
        CurrentRecourseIndex = index;
        CurrentResource = AvailableResources[CurrentRecourseIndex];
    }
}