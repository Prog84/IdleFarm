using System.Collections.Generic;

public class BuildingCraft: CraftingBuildings{
    
    public override void Init(TypeBuilding typeBuilding, List<TypeResource> availableRecourses, BuildingTimeCrate buildingTimeCrate) {

        TypeBuilding = typeBuilding;
        AvailableResources = availableRecourses;

        if (AvailableResources.Count > 0) {
            CurrentRecourseIndex = 0;
            CurrentResource = AvailableResources[CurrentRecourseIndex];
        }

        TimeToCreate = buildingTimeCrate.TimeToCrate;
        ProductionQuantity = buildingTimeCrate.ProductionQuantity;
    }
}