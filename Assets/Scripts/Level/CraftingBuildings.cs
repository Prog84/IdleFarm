using System.Linq;

public class CraftingBuildings : Building{
    protected float CurrentTime;
    protected float TimeToCreate;
    protected int ProductionQuantity;
    protected CraftItem CraftItem;

    protected override void OnProductionStarted(Building building, TypeResource currentResource) {
        if (building.Equals(this)) {
            SetCurrentResource(currentResource);
            var craftItem = PlayerData.Instance.CraftData.CraftItems.FirstOrDefault(i =>
                i.CraftResource == CurrentResource);
            CraftItem = craftItem;
            if (!IsWorking) {
                IsWorking = true;
            }
            else {
                IsWorking = false;
                CurrentTime = TimeToCreate;
            }
        }
    }
}