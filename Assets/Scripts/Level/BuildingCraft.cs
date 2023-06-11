using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingCraft: CraftingBuildings{

    private void Update() {
        if (IsWorking) {
            if (CurrentTime > 0) {
                CurrentTime -= Time.deltaTime;

                if (CurrentTime <= 0) {
                    EventsHolder.SetResourceProduced(CurrentResource, ProductionQuantity);
                    var isEnough = CheckCraft();
                    if (isEnough) {
                        EventsHolder.RemoveResourcesToCraft(CraftItem.NeedFirstResource, CraftItem.NeedSecondResource);
                    }
                    else {
                        IsWorking = false;
                        EventsHolder.StopCraft(CurrentResource);
                    }
                    CurrentTime = TimeToCreate;   
                }
            }
        }
    }


    public override void Init(TypeBuilding typeBuilding, List<RecourseItem> availableRecourses, BuildingTimeCrate buildingTimeCrate) {

        TypeBuilding = typeBuilding;
        AvailableResources = availableRecourses;

        /*if (AvailableResources.Count > 0) {
            CurrentRecourseIndex = 0;
            CurrentResource = AvailableResources[CurrentRecourseIndex].TypeResource;
        }*/

        TimeToCreate = buildingTimeCrate.TimeToCrate;
        CurrentTime = TimeToCreate;
        ProductionQuantity = buildingTimeCrate.ProductionQuantity;
        
    }

    private bool CheckCraft() {
        var firstRes = PlayerData.Instance.CraftData.CraftItems.FirstOrDefault(i =>
            i.CraftResource == CurrentResource);

        if (firstRes != null) {

            var isEnough = PlayerData.Instance.CheckCountResources(firstRes);

            if (isEnough) {
                return true;
            }
            else {
                return false;
            }
        }
        return false;
    }
}